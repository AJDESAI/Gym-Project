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
    public partial class addPlan : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public addPlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into Plan values('"+txtPlanType.Text+"','"+txtAmount.Text+"')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Plans are Added Successfully");
                txtPlanType.Clear();
                txtAmount.Clear();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror:"+ex);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPlanType.Clear();
            txtAmount.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
