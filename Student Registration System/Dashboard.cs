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
    public partial class Dashboard : Form
    {
        Functions Con;
        public Dashboard()
        {
            InitializeComponent();
            Con=new Functions();
            CountStudents();
            CountDepartments();
            CountMale();
            CountFemale();
        }
        private void CountStudents()
        {
            string Query = "select Count(*) as Stud from StudentTb1";
            foreach(DataRow dr in Con.GetData(Query).Rows) 
            {
                StudNumlbl.Text = dr["Stud"].ToString();
            }
            Studentlbl.Text = Con.GetData(Query).Columns["Stud"].ToString();
            
          //  StudNumlbl.DataSource = Con.GetData(Query);
        }

        private void CountDepartments()
        {
            string Query = "select Count(*) as Dep from DepartmentTb1";
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                DepNumlbl.Text = dr["Dep"].ToString();
            }
           

            //  StudNumlbl.DataSource = Con.GetData(Query);
        }

        private void CountMale()
        {
            string Gen = "Male";
            string Query = "select Count(*) as Male from StudentTb1 where StGen = '{0}'";
            Query = string.Format(Query, Gen);
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                MaleStudlbl.Text = dr["Male"].ToString();
            }
        }

        private void CountFemale()
        {
            string Gen = "Female";  // Assuming 'Female' is the value in your database for female students
            string Query = "select Count(*) as Female from StudentTb1 where StGen = '{0}'";
            Query = string.Format(Query, Gen);

            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                FemaleStudlbl.Text = dr["Female"].ToString();
            }
        }


        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Studentlbl_Click(object sender, EventArgs e)
        {
            Students Obj = new Students();
            Obj.Show();
            this.Close();
        }

        private void Departmentlbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Close();
        }

        private void StudNumlbl_Click(object sender, EventArgs e)
        {

        }
    }
}
