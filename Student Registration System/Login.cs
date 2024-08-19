using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Registration_System
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Set the UseSystemPasswordChar property to true for the Password TextBox
			PasswordTb.UseSystemPasswordChar = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (UNameTb.Text == "" || PasswordTb.Text == "")
			{
				MessageBox.Show("Missing Data!!! ");
			}
			else if (UNameTb.Text == "Admin" && PasswordTb.Text == "Admin")
			{
				Students Obj = new Students();
				Obj.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Wrong User Name or Password");
				UNameTb.Text = "";
				PasswordTb.Text = "";
			}
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
