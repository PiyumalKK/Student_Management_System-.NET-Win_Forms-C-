using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Student_Registration_System
{
    public partial class Students : Form
    {
        Functions Con;

        public Students()
        {
            InitializeComponent();
            Con=new Functions();
            ShowStudents();
            GetDepartment();
        }
        private void ShowStudents()
        {
            string Query = "select * from StudentTb1";
            Studentslist.DataSource = Con.GetData(Query);
        }

        private void GetDepartment()
        {
            string Query = "select * from DepartmentTb1";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepID"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Clear()
        {
            StNameTb.Text = "";
            StPhoneTb.Text = "";
            StIDTb.Text = "";
            StAddTb.Text = "";
            GenCb.SelectedIndex = -1;
            DepCb.SelectedIndex = -1;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StPhoneTb.Text == "" || StIDTb.Text=="" || StAddTb.Text==""|| DepCb.SelectedIndex== -1|| GenCb.SelectedIndex== -1)
            {
                MessageBox.Show("Missing Data!!");

            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Address = StAddTb.Text;
                    string ID1 = StIDTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "insert into StudentTb1 values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, TName, Gender,Phone,ID1, Address, Dep);
                    Con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Added !!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;

        private void Studentslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StNameTb.Text = Studentslist.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = Studentslist.SelectedRows[0].Cells[2].Value.ToString();
            StPhoneTb.Text = Studentslist.SelectedRows[0].Cells[3].Value.ToString();
            StIDTb.Text = Studentslist.SelectedRows[0].Cells[5].Value.ToString();
            StAddTb.Text = Studentslist.SelectedRows[0].Cells[4].Value.ToString();
            DepCb.SelectedValue = Studentslist.SelectedRows[0].Cells[6].Value.ToString();
            if (StNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(Studentslist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StPhoneTb.Text == "" || StIDTb.Text == "" || StAddTb.Text == "" || DepCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!");

            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Address = StAddTb.Text;
                    string ID1 = StIDTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "Update StudentTb1 set StName = '{0}', StGen='{1}', StPhone='{2}', StID='{3}', StAdd='{4}', StDepartment={5} where StCode={6}";
                    Query = string.Format(Query, TName, Gender, Phone, Address, ID1, Dep,Key);
                    Con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Updated !!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key==0)
            {
                MessageBox.Show("Missing Data!!");

            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Address = StAddTb.Text;
                    string ID1 = StIDTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "Delete from StudentTb1 where StCode={0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Deleted !!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Deplbl_Click(object sender, EventArgs e)
        {
            Departments Obj=new Departments();
            Obj.Show();
            this.Close();
        }

        private void Dashboardlbl_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Close();
        }
    }
}
