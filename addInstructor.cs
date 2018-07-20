using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class addInstructor : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public addInstructor()
        {
            InitializeComponent();
        }
        public void autogenerate_Instructor()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select max(instructor_id) from Instructor";
            cmd.ExecuteNonQuery();
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int a;
            if (dr.HasRows)
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtId.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtId.Text = a.ToString();
                }
            }
            dr.Dispose();
            con.Close();

        }
        private void addInstructor_Load(object sender, EventArgs e)
        {
            autogenerate_Instructor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Please Enter Instructor ID");
                return;
            }
            else if (txtFirstName.Text == "")
            {

                MessageBox.Show("Please enter Instructor First Name");
                return;
            }
            else if (txtLastName.Text == "")
            {

                MessageBox.Show("Please enter Instructor Last Name");
                return;
            }
            else if (txtConatctNo.TextLength < 10)
            {

                MessageBox.Show("Invalid Number or Please enter Member Contact number");
                return;
            }
            else if (TxtAddress.Text == "")
            {

                MessageBox.Show("Please enter Address Of Instructor");
                return;
            }
            else if (txtSalary.Text == "")
            {

                MessageBox.Show("Salary Not Mensioned!!");
                return;
            }
            else if (txtSpecialization.Text == "")
            {

                MessageBox.Show("No Specialization Added!!");
                return;
            }



            try
            {
                con.Open();
                cmd.Connection = con;
                string dojI=dobPicker.Value.ToString("dd-MM-yyyy");
                string sc=cmbSchedule.SelectedItem.ToString();
                cmd.CommandText = "insert into Instructor values('"+txtId.Text+"','"+txtFirstName.Text+"','"+txtLastName.Text+"','"+txtConatctNo.Text+"','"+TxtAddress.Text+"','"+dojI+"','"+sc+"','"+txtSalary.Text+"','"+txtSpecialization.Text+"')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
                clr();
                con.Close();
                autogenerate_Instructor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
                con.Close();
            }
        }
        public void clr()
        {
            txtId.Clear();
            txtLastName.Clear();
            txtSalary.Clear();
            txtSpecialization.Clear();
            txtFirstName.Clear();
            txtConatctNo.Clear();
            TxtAddress.Clear();
            cmbSchedule.SelectedIndex = -1;


        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
