using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPlan add = new addPlan();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
 
        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addMember add = new addMember();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        
        }

        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addInstructor add = new addInstructor();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void addToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            addEquipment add = new addEquipment();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        
        }

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            updateMember add = new updateMember();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void updateToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            updateInstructor add = new updateInstructor();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void updateToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            updateEquipment add = new updateEquipment();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void viewAllMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMember add = new ViewMember();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void viewAllInstructorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewInstructor add = new ViewInstructor();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void viewAllPlansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewPlan add = new ViewPlan();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void viewAllEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEquipment add = new ViewEquipment();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contact c = new contact();
            c.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about add = new about();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void removeMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
           RemoveMember  add = new RemoveMember();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void deletePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletePlan add = new DeletePlan();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void deleteInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteInstructor add = new DeleteInstructor();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }

        private void deleteEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEquipment add = new DeleteEquipment();
            add.MdiParent = this;
            add.Visible = true;
            add.Show();
        }
    }
}
