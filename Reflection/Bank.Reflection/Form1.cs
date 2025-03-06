using System.Reflection;
using Bank.Reflection.Context;
using Bank.Reflection.Entities;
using Bank.Reflection.Migrations;
using Bank.Reflection.Reflection;
using Bank.Reflection.Services.Abstract;
using CustomAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace Bank.Reflection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}


		// Ödeme Yap
		private async void button1_Click(object sender, EventArgs e)
		{
			try
			{
				double amaount = double.Parse(textBox1.Text);
				string paymentMethodID = comboBox1!.SelectedValue!.ToString()!;
				string paymentMethodValue = (comboBox1.SelectedItem as PaymentMethod)?.Value!;
				string paymentMethodDisplayName = (comboBox1.SelectedItem as PaymentMethod)?.DisplayName!;

				using BankContext context = new BankContext();


				context.PaymentTransactions.Add(new PaymentTransaction
				{
					Amount = amaount,
					PaymentMethodId = Guid.Parse(paymentMethodID)
				});

				int result = await context.SaveChangesAsync();

				if (result == 1)
				{
					// Ödeme yapýlmak istenen yöntemin class ve instance oluþturur	
					Type paymentType = CreatePaymentClass.CreateOrLoadPaymentType(paymentMethodDisplayName, paymentMethodValue);
					IPayment paymentInstance = (IPayment)Activator.CreateInstance(paymentType);

					LoadDataGridData();
					
					MessageBox.Show($"{paymentInstance.ProcessPayment(amaount)}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBox1.Clear();
				}

			}catch(Exception ex) {
				LoadComboboxData();
				MessageBox.Show("Error!: "+ ex.Message);
			}

			
		}

		//Ödeme yöntemini ve class'ýný oluþturur
		private async void button2_Click(object sender, EventArgs e)
		{
			string displayName = textBox2.Text;

			// **** CUSTOM VALÝDASYONU DENEMEK ÝÇÝN YORUM SATIRINA ALINDI ****
			//if (displayName == string.Empty)
			//{
			//	MessageBox.Show($"Payment method can not empty");
			//	return;
			//}

			// displayName deki Kalimelerin baþ harlerini büyük harfe çevirip aradaki boþluklarý siler.
			string value = string.Join("", displayName
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));

			try
			{
				using var context = new BankContext();

				PaymentMethod paymentMethod = new PaymentMethod
				{
					Value = value,
					DisplayName = displayName
				};

				// CustomAttribute ile validasyon kontrolü saðlar
				bool valid = CustomValidation.Validate(paymentMethod);

				if (!valid)
				{
					throw new Exception($"Payment method can not empty");
				
				}

				context.PaymentMethods.Add(paymentMethod);

				var result = await context.SaveChangesAsync();

				if (result == 1)
				{
					//Type paymentType = CreatePaymentClass.CreateOrLoadPaymentType(displayName, value);

					LoadComboboxData();
					MessageBox.Show($"Payment method '{displayName}' has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


				}
				else
				{

					throw new Exception("Payment method could not be added!");
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show($"An error occurred while adding the payment method.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			textBox2.Clear();

		}


		private  void Form1_Load(object sender, EventArgs e)
		{
			LoadComboboxData();

			dataGridView1.Columns.Add("PaymentMethod", "Payment Method");
			dataGridView1.Columns.Add("Amount", "Amount");
			dataGridView1.Columns.Add("PaymentDate", "Payment Date");

			// Data Grid geniþlik ayarý
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			LoadDataGridData();

		}

		private async void LoadComboboxData()
		{
			comboBox1.DataSource = null;

			using BankContext context = new BankContext();

			ICollection<PaymentMethod> paymentMethods = await context.PaymentMethods.ToListAsync();

			// PaymentMethod nesnelerini ComboBox'a ekler
			comboBox1.DataSource = paymentMethods.ToList();
			comboBox1.DisplayMember = "DisplayName";
			comboBox1.ValueMember = "Id";


			if (comboBox1.Items.Count > 0)
				comboBox1.SelectedIndex = 0;
		}

		private  async void LoadDataGridData()
		{
			dataGridView1.Rows.Clear();
			using BankContext context = new BankContext();
			ICollection<PaymentTransaction> paymentTransaction = await context.PaymentTransactions.Include(pt => pt.PaymentMethod).ToListAsync();

			foreach (PaymentTransaction transaction in paymentTransaction)
			{
				    dataGridView1.Rows.Add(
					transaction.PaymentMethod?.DisplayName, 
					transaction.Amount,
					transaction.CreatedDate.ToString("dd-MM-yyyy") 
				   );
			}	
		}

	}
}
