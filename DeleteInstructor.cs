﻿using System;
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
    public partial class DeleteInstructor : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajit\Documents\Visual Studio 2012\Projects\WindowsFormsApplication2\Database\gymManagement.accdb");
        OleDbCommand cmd = new OleDbCommand();

        public DeleteInstructor()
        {
            InitializeComponent();
        }

        private void DeleteInstructor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             con.Open();
            cmd.Connection = con;
            DialogResult dr = MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cmd.CommandText = "delete from Instructor where instructor_id='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Instructor Deleted!!");
                textBox1.Clear();
        }
            con.Close();
    }

        private void button2_Click(object sender, EventArgs e)
        {
             textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
}
}