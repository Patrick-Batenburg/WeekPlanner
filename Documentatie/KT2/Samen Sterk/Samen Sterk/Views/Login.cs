using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class Login : Form
    {
        UserController userController = new UserController();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int result = userController.Login(new User() { Username = txtUsername.Text, Password = txtPassword.Text});
            if (result == 1)
            {
                Shedule shedule = new Shedule(this);
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
            Register register = new Register(this);
            register.Show();
            this.Hide();
        }
    }
}
