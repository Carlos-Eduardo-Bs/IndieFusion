using IndieDesk.Adm;
using IndieFusionDesk.Adm;
using IndieFusionDesk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndieDesk
{
    public partial class mdiUser : Form
    {
        public mdiUser()
        {
            InitializeComponent();
        }

        private void mdiUser_Load(object sender, EventArgs e)
        {
            if (UserSession.Name != null)
            {
                lblSession.Text = $"User: {UserSession.Name.ToUpper()} - sua sessão iniciou as {DateTime.Now.ToString("t")}";
            }

        }

        private void tsmiSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiListar_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }



        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUser frm = new frmManageUser();
            frm.ShowDialog();
        }

        private void controleTipoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUserType frm = new frmManageUserType();
            frm.ShowDialog();
        }

        private void tsmiEditarType_Click(object sender, EventArgs e)
        {

        }

        private void tsmiListarType_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmManageUser frm = new frmManageUser();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmManageUserType frm = new frmManageUserType();
            frm.ShowDialog();
        }
    }
}
