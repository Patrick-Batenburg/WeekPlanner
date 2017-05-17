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
                if (result == 1)
                {
                    MessageBox.Show("Succesvol geregistreerd");
                    this.Close();
                }
                else if (result == 2)
                {
                    MessageBox.Show("Gebruikersnaam is ongeldig.");
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
