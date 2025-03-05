using System.Reflection;
using Bank.Reflection.Context;
using Bank.Reflection.Data;
using Bank.Reflection.Entities;
using Bank.Reflection.Migrations;
using Bank.Reflection.Reflection;
using Bank.Reflection.Services.Abstract;

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
	

				using BankContext contex = new BankContext();	
				var repo = new Commands(contex);

				int result = await repo.AddPaymentTransactionAsync(new PaymentTransaction
				{
					Amount = amaount,
					PaymentMethodId = Guid.Parse(paymentMethodID)
				});

				if (result == 1)
				{
					// Oluþturulan class'ýn instance'ý oluþturma
					Type paymentType = Type.GetType($"Bank.Reflection.Services.Concrete.{paymentMethodValue}");
					IPayment paymentInstance = (IPayment)Activator.CreateInstance(paymentType);

					LoadDataGridData();
					
					MessageBox.Show($"{paymentInstance.ProcessPayment(amaount)}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBox1.Clear();
				}

			}catch(Exception ex) {
				MessageBox.Show("Error!: "+ ex.Message);
			}

			
		}

		//Ödeme yöntemini ve class'ýný oluþturur
		private async void button2_Click(object sender, EventArgs e)
		{
			string displayName = textBox2.Text;
			if (displayName == "")
			{
				MessageBox.Show($"Payment method can not empty");
				return;
			}
			// displayName deki Kalimelerin baþ harlerini büyük harfe çevirip aradaki boþluklarý siler.
			string value = string.Join("", displayName
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));

			try
			{
				using var context = new BankContext();
				var repo = new Commands(context);
				int result = await repo.AddPaymentMethodAsync(new PaymentMethod
				{
					Value = value,
					DisplayName = displayName
				});

				if (result == 1)
				{
					Type paymentType = CreatePaymentClass.CreateOrLoadPaymentType(displayName, value);
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
			var repo = new Queries(context);
			ICollection<PaymentMethod> paymentMethods = await repo.GetAllPaymentMethodAsync();

			// PaymentMethod nesnelerini ComboBox'a ekler
			comboBox1.DataSource = paymentMethods.ToList();
			comboBox1.DisplayMember = "DisplayName";
			comboBox1.ValueMember = "Id";


			if (comboBox1.Items.Count > 0)
				comboBox1.SelectedIndex = 0;
		}

		private async void LoadDataGridData()
		{
			dataGridView1.Rows.Clear();
			using BankContext context = new BankContext();
			var repo = new Queries(context);
			ICollection<PaymentTransaction> paymentMethods = await repo.GetAllPaymentTransactionAsync();

			foreach(PaymentTransaction transaction in paymentMethods)
			{
				    dataGridView1.Rows.Add(
					transaction.PaymentMethod?.DisplayName, 
					transaction.Amount,
					transaction.CreatedDate.ToString("dd-mm-yyyy") 
				   );
			}	
		}

	}
}
