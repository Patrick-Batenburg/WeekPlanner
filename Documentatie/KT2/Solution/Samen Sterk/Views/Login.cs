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

        /// <summary>
        /// Initializes a new instance of the form Login class.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.FormClosing += Login_FormClosing;
        }

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Occurs when the Label control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblRegister_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            Register register = new Register(this);
            register.Show();
            this.Hide();
        }

        /// <summary>
        /// Occurs before the form is closed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param> 
        void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}