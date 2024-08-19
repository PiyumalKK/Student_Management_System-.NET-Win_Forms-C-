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
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments(); 
        }

        private void ShowDepartments()
        {
            string Query = "select * from DepartmentTb1";
            Departmentslist.DataSource = Con.GetData(Query);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Departments_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(DepNameTb.Text==""||DetailsTb.Text=="")
            {
                MessageBox.Show("Missing Data!!");

            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "insert into DepartmentTb1 values('{0}','{1}')";
                    Query=string.Format(Query, DName, Details);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added !!");
                    Clear();
                }
                catch(Exception Ex)
                {
                   MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void Departmentslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = Departmentslist.SelectedRows[0].Cells[1].Value.ToString();
            DetailsTb.Text = Departmentslist.SelectedRows[0].Cells[2].Value.ToString();
            if(DepNameTb.Text=="")
            {
                Key = 0;
            }
            else 
            {
            Key=Convert.ToInt32(Departmentslist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");

            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "Update DepartmentTb1 set DepName ='{0}', DepDetails = '{1}' where DepID = {2}";
                    Query = string.Format(Query, DName, Details, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated !!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Clear()
        {
            DepNameTb.Text = "";
            DetailsTb.Text = "";

        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Department!!");

            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "Delete from DepartmentTb1 where DepID = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted !!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Close();
        }

        private void Studentlbl_Click(object sender, EventArgs e)
        {
            Students Obj = new Students();
            Obj.Show();
            this.Close();
        }

        private void Dashboardlbl_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }
    }
}
