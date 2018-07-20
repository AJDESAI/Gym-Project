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
    public partial class addEquipment : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public addEquipment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEquipmentId.Text == "")
            {
                MessageBox.Show("Please Enter Equipment ID");
                return;
            }
            else if (txtEquipmentName.Text == "")
            {

                MessageBox.Show("Please enter EquipmentName ");
                return;
            }
            else if (txtEquipmentCompany.Text == "")
            {

                MessageBox.Show("Please enter Equipment company Name ");
                return;
            }
            else if (txtEqupmentPrice.Text == "")
            {

                MessageBox.Show("Please enter Equipment Price ");
                return;
            }
            else if (txtTotalEquipmentQuantity.Text == "")
            {

                MessageBox.Show("Please enter Equipment Total Quantity ");
                return;
            }
            
            
            
            try
            {
                con.Open();
                cmd.Connection = con;
                string dt=dobEqupment.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "insert into equipment values('"+txtEquipmentId.Text+"','"+txtEquipmentName.Text+"','"+txtEquipmentCompany.Text+"','"+txtTotalEquipmentQuantity.Text+"','"+txtEqupmentPrice.Text+"','"+dt+"','"+txtTotalPrice.Text+"')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
                clear();
                con.Close();
                autogenerate_Equipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
                con.Close();
            }
        }
        public void clear()
        {
            txtTotalPrice.Clear();
            txtTotalEquipmentQuantity.Clear();
            txtEqupmentPrice.Clear();
            txtEquipmentName.Clear();
            txtEquipmentId.Clear();
            txtEquipmentCompany.Clear();


        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtTotalEquipmentQuantity_Leave(object sender, EventArgs e)
        {
            if (txtEqupmentPrice.Text == "")
            {
                MessageBox.Show("Please enter Price");
                return;
            }
            else if(txtTotalEquipmentQuantity.Text == "")
            {

                MessageBox.Show("Please enter Quantity");
                return;

            }
            int x = Convert.ToInt32(txtEqupmentPrice.Text);
            int y = Convert.ToInt32(txtTotalEquipmentQuantity.Text);
            
            int sum = x * y;
            txtTotalPrice.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void autogenerate_Equipment()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select max(equipment_id) from Equipment";
            cmd.ExecuteNonQuery();
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int a;
            if (dr.HasRows)
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtEquipmentId.Text= "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtEquipmentId.Text = a.ToString();
                }
            }
            dr.Dispose();
            con.Close();

        }
        private void addEquipment_Load(object sender, EventArgs e)
        {
            autogenerate_Equipment();
        }
    }
}
