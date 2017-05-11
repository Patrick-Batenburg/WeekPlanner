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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmShedule shedule = new frmShedule(this);
            shedule.Show();
            this.Hide();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister(this);
            register.Show();
            this.Hide();
        }
    }
}
