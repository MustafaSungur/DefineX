namespace Bank.Reflection
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			label1 = new Label();
			comboBox1 = new ComboBox();
			label2 = new Label();
			textBox1 = new TextBox();
			dataGridView1 = new DataGridView();
			label4 = new Label();
			button2 = new Button();
			textBox2 = new TextBox();
			label3 = new Label();
			label5 = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// button1
			// 
			button1.BackColor = Color.MediumSlateBlue;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Segoe UI", 12F);
			button1.ForeColor = SystemColors.ButtonHighlight;
			button1.Location = new Point(75, 200);
			button1.Name = "button1";
			button1.Size = new Size(314, 46);
			button1.TabIndex = 0;
			button1.Text = "Complete Payment";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(75, 78);
			label1.Name = "label1";
			label1.Size = new Size(128, 21);
			label1.TabIndex = 1;
			label1.Text = "Payment Method";
			// 
			// comboBox1
			// 
			comboBox1.Font = new Font("Segoe UI", 12F);
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(212, 75);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(177, 29);
			comboBox1.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(75, 140);
			label2.Name = "label2";
			label2.Size = new Size(112, 21);
			label2.TabIndex = 3;
			label2.Text = "Amount to Pay";
			// 
			// textBox1
			// 
			textBox1.Font = new Font("Segoe UI", 12F);
			textBox1.Location = new Point(212, 137);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(177, 29);
			textBox1.TabIndex = 4;
			// 
			// dataGridView1
			// 
			dataGridView1.BackgroundColor = Color.White;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(75, 273);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(986, 332);
			dataGridView1.TabIndex = 5;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F);
			label4.Location = new Point(747, 113);
			label4.Name = "label4";
			label4.Size = new Size(128, 21);
			label4.TabIndex = 7;
			label4.Text = "Payment Method";
			// 
			// button2
			// 
			button2.BackColor = Color.MediumSlateBlue;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Font = new Font("Segoe UI", 12F);
			button2.ForeColor = SystemColors.ButtonHighlight;
			button2.Location = new Point(747, 200);
			button2.Name = "button2";
			button2.Size = new Size(314, 46);
			button2.TabIndex = 6;
			button2.Text = " Add Payment Method";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// textBox2
			// 
			textBox2.Font = new Font("Segoe UI", 12F);
			textBox2.Location = new Point(884, 110);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(177, 29);
			textBox2.TabIndex = 8;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(747, 27);
			label3.Name = "label3";
			label3.Size = new Size(165, 25);
			label3.TabIndex = 9;
			label3.Text = "Payment Method";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(75, 27);
			label5.Name = "label5";
			label5.Size = new Size(159, 25);
			label5.TabIndex = 10;
			label5.Text = "Make a Payment";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.WhiteSmoke;
			ClientSize = new Size(1150, 649);
			Controls.Add(label5);
			Controls.Add(label3);
			Controls.Add(textBox2);
			Controls.Add(label4);
			Controls.Add(button2);
			Controls.Add(dataGridView1);
			Controls.Add(textBox1);
			Controls.Add(label2);
			Controls.Add(comboBox1);
			Controls.Add(label1);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Label label1;
		private ComboBox comboBox1;
		private Label label2;
		private TextBox textBox1;
		private Label label4;
		private Button button2;
		private TextBox textBox2;
		private Label label3;
		private Label label5;
		public DataGridView dataGridView1;
	}
}
