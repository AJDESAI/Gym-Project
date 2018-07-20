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
    public partial class updateMember : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public updateMember()
        {
            InitializeComponent();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from Membership where member_id='" + txtMemberID.Text + "'";
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
                    txtAmount.Text = dr["Amount"].ToString();

                }
                else
                {

                    MessageBox.Show("This member not found in Database","Not Found Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    clear();
                }

                con.Close();
                dr.Dispose();
            }
                
            
            catch (Exception ex)
            {

                MessageBox.Show("Error"+ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                string dt = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "update membership set FirstName='"+txtFirstName.Text+"',LastName='"+txtLastName.Text+"',contactno='"+txtContactNo.Text+"',address='"+txtAddress.Text+"',doj='"+dt+"',amount='"+txtAmount.Text+"' where member_id='"+txtMemberID.Text+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                
                con.Close();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
                con.Close();

            }
        }
       
        public void clear()
        {

            txtFirstName.Clear();
            txtLastName.Clear();
            txtContactNo.Clear();
            txtAddress.Clear();
            txtMemberID.Clear();
            txtAmount.Clear();
            txtMemberID.Focus();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
