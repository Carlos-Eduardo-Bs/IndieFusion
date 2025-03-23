using IndieFusionDesk.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IndieFusionDesk.Adm
{
    public partial class frmManageUserType : Form
    {
        public frmManageUserType()
        {
            InitializeComponent();
        }

        private void frmManageUserType_Load(object sender, EventArgs e)
        {
            LoadDgv1();
            txtId.Enabled = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show($"Deseja realmente excluir esse Registro?", "ATENÇÂO!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                int idTypeUser = Convert.ToInt32(txtId.Text);
                var result = await UserTypeServices.DeleteUserType(idTypeUser);
                MessageBox.Show($"Tipo Usuário {txtDescription.Text.ToUpper()} Excluido com sucesso !!");
                LoadDgv1();
            }
            else if (msg == DialogResult.No)
            {
                ClearField();
            }
        }

        private void ClearField()
        {
            txtId.Text = txtDescription.Text = string.Empty;
            txtDescription.Focus();
        }

        private async void LoadDgv1()
        {
            var list = await UserTypeServices.GetUserType();
            dgv1.DataSource = list;
            dgv1.ClearSelection();
            ClearField();

            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv1.DefaultCellStyle.Font = new Font("Arial", 10);
            dgv1.RowHeadersVisible = false;
            dgv1.RowTemplate.Height = 120;
            dgv1.DefaultCellStyle.ForeColor = Color.Black;
        }

        //LoadField
        private void loadField()
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                UserType user = (UserType)dgv1.SelectedRows[0].DataBoundItem;
                txtId.Text = user.Id.ToString();
                txtDescription.Text = user.Description.ToString();

            }
        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                //Create user
                UserType userType = new UserType()
                {
                    Description = txtDescription.Text,
                };

                var result = await UserTypeServices.PostUserType(userType);
                MessageBox.Show($"Tipo usuário {userType.Description.ToUpper()} cadastrado com sucesso !!");
                LoadDgv1();
            }

            else if (!string.IsNullOrEmpty(txtId.Text))
            {
                //Update user
                UserType userType = new UserType()
                {
                    Id = int.Parse(txtId.Text),
                    Description = txtDescription.Text,
                };

                var result = await UserTypeServices.PutUserType(userType);
                MessageBox.Show($"Tipo usuário {userType.Description.ToUpper()} Editado com sucesso !!");
                LoadDgv1();
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadField();
        }
    }
}
