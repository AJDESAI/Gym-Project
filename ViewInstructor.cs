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
    public partial class ViewInstructor : Form
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public ViewInstructor()
        {
            InitializeComponent();
        }

        private void ViewInstructor_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                this.dataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 11);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Bright", 13);
                OleDbDataAdapter da = new OleDbDataAdapter("select * from Instructor", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }
    }
}
