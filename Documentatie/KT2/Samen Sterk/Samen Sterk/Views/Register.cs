using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class Register : Form
    {
        Login login;
        UserController userController = new UserController();
        public Register(Login login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtPasswordRepeat.Text)
            {
                int result = userController.Register(new User() { Username = txtUsername.Text, Password = txtPassword.Text, Role = "member" });
                switch (result)
                {
                    case 1:
                        MessageBox.Show("Succesvol geregistreerd");
                        this.Close();
                        break;
                    case 2:
                        MessageBox.Show("Gebruikersnaam is ongeldig.");
                        break;
                    case 3:
                        MessageBox.Show("Gebruikersnaam is al in gebruik.");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Het wachtwoord komt niet overeen");
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }
    }
}
