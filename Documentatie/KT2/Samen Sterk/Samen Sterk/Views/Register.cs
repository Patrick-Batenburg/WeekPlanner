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
    public partial class frmRegister : Form
    {
        frmLogin login;
        public frmRegister(frmLogin login)
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
            this.Close();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }
    }
}
