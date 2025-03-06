using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using Bank.Reflection.Services.Abstract;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace Bank.Reflection.Reflection
{
	public static class CreatePaymentClass
	{
		public static Type CreateOrLoadPaymentType(string displayName, string value)
		{
			string paymentTypeName = value; // Değer, sınıf adı olarak kullanılacak

			// Önce Concrete klasöründeki tipleri kontrol edelim
			var concreteType = Assembly.GetExecutingAssembly()
				.GetTypes()
				.FirstOrDefault(t => t.Namespace == "Bank.Reflection.Services.Concrete" && t.Name == paymentTypeName);

			if (concreteType != null)
				return concreteType; // Eğer tip Concrete klasöründe varsa, geri döndür

			// Dinamik olarak oluşturulacak C# kodunu tanımlar
			string code = $@"
using System;
using Bank.Reflection.Services.Abstract;

namespace Bank.Reflection.Services.Concrete
{{
    public class {paymentTypeName} : IPayment
    {{
        public string ProcessPayment(double amount) => 
           $""The payment of {{amount}} TL was successfully processed with {displayName}"";
    }}
}}";

			// Concrete klasörüne .cs dosyası olarak kaydet
			string projectDirectory = Path.GetFullPath(
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Services", "Concrete")
			);

			// Eğer klasör yoksa oluştur
			if (!Directory.Exists(projectDirectory))
			{
				Directory.CreateDirectory(projectDirectory);
			}

			// Dosya yolu oluştur
			string filePath = Path.Combine(projectDirectory, $"{paymentTypeName}.cs");

			// Dosyayı kaydet
			File.WriteAllText(filePath, code, Encoding.UTF8);

			Console.WriteLine($"Sınıf dosyası oluşturuldu: {filePath}");

			// Roslyn ile kodu derlemek için SyntaxTree oluşturur
			SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

			// Derleme için gerekli olan referansları tanımlar
			var references = new List<MetadataReference>
			{
				MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
				MetadataReference.CreateFromFile(typeof(IPayment).Assembly.Location),
			};


			// Roslyn kullanarak derleme işlemini başlatır
			var compilation = CSharpCompilation.Create(
				$"{paymentTypeName}_DynamicAssembly", // Derlenen assembly'nin adı
				new[] { syntaxTree }, // Derlenecek C# kodu
				references,
				new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary) // DLL olarak derleme seçeneği
			);

			using var ms = new MemoryStream();
			EmitResult result = compilation.Emit(ms);

			// Eğer derleme başarısız olursa detaylı hata fırlatır
			if (!result.Success)
			{
				var errors = string.Join("\n", result.Diagnostics
					.Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)
					.Select(diagnostic => diagnostic.ToString()));

				throw new Exception($"Derleme başarısız:\n{errors}");
			}

			// Belleğe yüklenen derlemeyi okur ve tipini döndürür
			ms.Seek(0, SeekOrigin.Begin);
			return Assembly.Load(ms.ToArray()).GetType($"Bank.Reflection.Services.Concrete.{paymentTypeName}");
		}
	}
}
