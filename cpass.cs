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
    public partial class cpass : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public cpass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "update tblLogin set G_Password='" + textBox2.Text + "'  where G_Username ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully");

            con.Close();
            
        }
    }
}
