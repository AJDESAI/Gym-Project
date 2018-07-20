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
    
    public partial class addMember : Form
    {
        
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();
        public addMember()
        {
            InitializeComponent();
        }
        public delegate void delPassData(TextBox text); 
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Member Name");
                return;
           }
            else if (textBox2.Text == "")
            {

                MessageBox.Show("Please enter Member Lastname");
                return;
            }
            else if (textBox3.TextLength < 10)
            {

                MessageBox.Show("Invalid Number or Please enter Member Contact number");
                return;
            }
            else if (textBox4.Text == "")
            {

                MessageBox.Show("Please enter Member Address");
                return;
            }
            else if (textBox6.Text == "")
            {

                MessageBox.Show("Please enter Member Amount");
                return;
            }
            try
            {
                con.Open();
                cmd.Connection = con;
                string dt = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                string plantype = cmbPlanType.SelectedItem.ToString();
                cmd.CommandText = "insert into Membership(member_id,FirstName,LastName,ContactNo,Address,Doj,Plan_type,Amount) values('" + txtMember.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dt + "','"+plantype+"','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Added Successfully!");

                
                if (checkBox1.Checked)
                {
                    BillGenearation frm = new BillGenearation();
                    delPassData del = new delPassData(frm.funData);
                    del(this.txtMember);
                    frm.Show();
                }
                clear();
                con.Close();
                autogenerate_member();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:"+ex);
            }
        }
       
        public void clear()
        {
            txtMember.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            cmbPlanType.SelectedIndex = -1;


        }
        public void autogenerate_member()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select max(member_id) from Membership";
            cmd.ExecuteNonQuery();
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int a;
            if (dr.HasRows)
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtMember.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtMember.Text = a.ToString();
                }
            }
            dr.Dispose();
            con.Close();
            
        }
        private void addMember_Load(object sender, EventArgs e)
        {
            try
            {
                autogenerate_member();
                con.Open();
                cmd.Connection = con;
                OleDbDataAdapter da = new OleDbDataAdapter("select * from Plan",con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    cmbPlanType.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured" + ex);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            try
            {
                string plan=cmbPlanType.SelectedItem.ToString();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select amount from plan where PlanType='" + plan + "'";
                cmd.ExecuteNonQuery();
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {

                    textBox6.Text=rd["amount"].ToString();
                }
                con.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Please select PlanType"+ex);

            }
        }

        private void txtMember_Click(object sender, EventArgs e)
        {
           
        }
    }
}
