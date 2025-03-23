using IndieFusionDesk.Models;
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

namespace IndieDesk
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            //verificacao user
            UserLogin login = new UserLogin()
            {
                NickName = txtNickName.Text,
                PasswordUser = txtPassword.Text
            };

            UserResponse response = await UserServices.Login(login);
            if (response == null)
            {
                MessageBox.Show("Login ou senha inválidos !!");
                return;
            }

            //preenchendo dados da sessao
            UserSession.IdUser = response.User.IdUser;
            UserSession.Name = response.User.Name;
            UserSession.Email = response.User.Email;
            UserSession.UserTp = response.User.UserTp;

            //token
            UserSession.Token = response.Token;



            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
