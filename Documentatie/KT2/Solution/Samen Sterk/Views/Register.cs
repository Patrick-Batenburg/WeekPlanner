﻿using SamenSterk.Controllers;
using SamenSterk.Models;
using System;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class Register : Form
    {
        private Login login;
        private UserController userController = new UserController();

        /// <summary>
        /// Initializes a new instance of the form Register class.
        /// </summary>
        /// <param name="login">Login form details to gain access to.</param>
        public Register(Login login)
        {
            this.login = login;
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtPasswordRepeat.Text)
            {
                int result = userController.Register(new User() { Username = txtUsername.Text, Password = txtPassword.Text, Role = "Member" });

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

        /// <summary>
        /// Occurs before the form is closed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }
    }
}