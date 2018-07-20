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
    public partial class updateEquipment : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public updateEquipment()
        {
            InitializeComponent();
        }

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from equipment where equipment_id='" + txtEquipmentId.Text + "'";
                cmd.ExecuteNonQuery();

                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtEquipmentName.Text = dr["NOE"].ToString();
                    txtEquipmentCompany.Text = dr["Company"].ToString();
                    txtTotalEquipmentQuantity.Text = dr["TotalQ"].ToString();
                    txtEqupmentPrice.Text = dr["PPU"].ToString();
                    dobEqupment.Text = dr["DOI"].ToString();
                    txtTotalPrice.Text = dr["TotalPrice"].ToString();
                }
                else
                {

                    MessageBox.Show("No equipment found in Database", "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtEquipmentId.Clear();
            txtEquipmentCompany.Clear();
            txtEquipmentName.Clear();
            txtEqupmentPrice.Clear();
            txtTotalEquipmentQuantity.Clear();
            txtTotalPrice.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                string dt = dobEqupment.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "update equipment set NOE='" + txtEquipmentName.Text + "',Company='" + txtEquipmentCompany.Text + "',TotalQ='" + txtTotalEquipmentQuantity.Text + "',PPU='" + txtEqupmentPrice.Text + "',DOI='" + dt + "',TotalPrice='" + txtTotalPrice.Text + "' where equipment_id='"+txtEquipmentId.Text+"'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTotalEquipmentQuantity_Leave(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32(txtEqupmentPrice.Text);
            int y = Convert.ToInt32(txtTotalEquipmentQuantity.Text);
            int sum = x * y;
            txtTotalPrice.Text = sum.ToString();
        }
    }
}
