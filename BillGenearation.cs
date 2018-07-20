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
using System.Drawing.Printing;
namespace WindowsFormsApplication2
{
    public partial class BillGenearation : Form
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public BillGenearation()
        {
            InitializeComponent();
           
        }
        public string m_id;
        public void funData(TextBox txtForm1)
        {
            
           m_id = txtForm1.Text;
        }
        private void BillGenearation_Load(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from Membership where member_id='"+m_id+"'";
                cmd.ExecuteNonQuery();
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    string fname = rd["FirstName"].ToString();
                    string lname = rd["LastName"].ToString();
                    string fullname = fname + " " +lname;
                    txtFullName.Text = fullname;
                    txtContact.Text = rd["ContactNo"].ToString();
                    txtDOJ.Text = rd["Doj"].ToString();
                    txtPlanj.Text = rd["Plan_type"].ToString();
                    txtAmount.Text = rd["Amount"].ToString();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error"+ex);
            }
        }
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(memoryImage, 0, 0);

        }
        Bitmap memoryImage;
        private void CaptureScreen()
        {

            Graphics myGraphics = this.CreateGraphics();

            Size s = this.Size;

            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);

            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();

            document.PrintPage += new PrintPageEventHandler(document_PrintPage);

            CaptureScreen();

            document.Print();
        }
    }
}
