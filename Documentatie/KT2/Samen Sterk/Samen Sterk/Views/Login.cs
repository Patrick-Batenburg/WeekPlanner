using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class Login : Form
    {
        private UserController userController = new UserController();
        private User user;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user = userController.Login(user = new User() { Username = txtUsername.Text, Password = txtPassword.Text });

            if (user != null)
            {
                Shedule shedule = new Shedule(user);
                shedule.Show();
                txtUsername.Text = "";
                this.Hide();
            }
            else
            {
                MessageBox.Show("De gebruikersnaam of wachtwoord is onjuist");
            }

            txtPassword.Text = "";
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            Register register = new Register(this);
            register.Show();
            this.Hide();
        }
    }
}