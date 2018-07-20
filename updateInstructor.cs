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
    public partial class updateInstructor : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public updateInstructor()
        {
            InitializeComponent();
        }

        private void updateInstructor_Load(object sender, EventArgs e)
        {

        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from Instructor where instructor_id='" + txtInstructorID.Text + "'";
                cmd.ExecuteNonQuery();

                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtFirstName.Text = dr["FirstName"].ToString();
                    txtLastName.Text = dr["LastName"].ToString();
                    txtContactNo.Text = dr["ContactNo"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    dateTimePicker1.Text = dr["Doj"].ToString();
                    cmbSchedule.Text = dr["Schedule"].ToString();
                    txtAmount.Text = dr["salary"].ToString();
                    txtSpecialization.Text = dr["specialization"].ToString();
                }
                else
                {

                    MessageBox.Show("This Instructor not found in Database", "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
                con.Close();
                dr.Dispose();
            }


            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }
        public void clear()
        {
            txtInstructorID.Clear();
            txtLastName.Clear();
            txtSpecialization.Clear();
            txtFirstName.Clear();
            txtContactNo.Clear();
            txtAmount.Clear();
            txtAddress.Clear();
            cmbSchedule.SelectedIndex = -1;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtInstructorID.Text == "")
            {
                MessageBox.Show("Please Enter Instructor ID");
                return;
            }
            else if (txtFirstName.Text == "")
            {

                MessageBox.Show("Please enter First Name");
                return;
            }
            else if (txtLastName.Text == "")
            {

                MessageBox.Show("Please enter Last Name");
                return;
            }

            else if (txtContactNo.TextLength < 10)
            {

                MessageBox.Show("Invalid Number or Please enter Member Contact number");
                return;
            }
            else if (txtAddress.Text == "")
            {

                MessageBox.Show("Please enter Address");
                return;
            }
            else if (txtAmount.Text == "")
            {

                MessageBox.Show("Please enter Amount");
                return;
            }
            
            try
            {
                con.Open();
                cmd.Connection = con;
                string dt = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "update Instructor set FirstName='" + txtFirstName.Text + "',LastName='" + txtLastName.Text + "',contactno='" + txtContactNo.Text + "',address='" + txtAddress.Text + "',doj='" + dt + "',schedule='" + cmbSchedule.SelectedItem.ToString() + "',salary='" + txtAmount.Text + "',specialization='" + txtSpecialization.Text + "' where instructor_id='" + txtInstructorID.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                clear();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                con.Close();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
