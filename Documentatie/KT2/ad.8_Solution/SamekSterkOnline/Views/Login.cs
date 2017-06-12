using SamenSterkOnline.Controllers;
using SamenSterkOnline.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SamenSterkOnline.Views
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
        /// Occurs when the Button control is clicked. Sign the user in.
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
        /// Occurs when the Label control is clicked. Displays the Register form.
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
        /// Occurs before the form is closed. Exits the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus. Activates the next control when the enter key is pressed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Select();
            }
        }

        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus. Activates the next control when the enter key is pressed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the control. Sets the foreground color of the Label control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.Blue;
        }

        /// <summary>
        /// Occurs when the mouse pointer enters the control. Sets the foreground color of the Label control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.Orchid;
        }
    }
}