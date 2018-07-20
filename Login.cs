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
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        
                if(txtUsername.Text=="")
                {
                    MessageBox.Show("Plese Enter username","Login Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                   
                }
                else if(txtPassword.Text=="")
                {
                    MessageBox.Show("Plese enter Password", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;   

                }
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from tblLogin where G_Username='" + txtUsername.Text + "' and G_Password='" + txtPassword.Text + "'";
                    cmd.ExecuteNonQuery();

                    OleDbDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        Main a = new Main();
                        a.Show();
                        clear();
                        this.Hide();
                    }
                    else
                    {

                        MessageBox.Show("Invalid username and password", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clear();
                    }
                    con.Close();
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured"+ex);
                    con.Close();
                }

            }

        

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
