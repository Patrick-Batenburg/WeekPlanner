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
    public partial class frmAddTask : Form
    {
        frmShedule shedule;
        string title;
        int duration;
        string label;
        public frmAddTask(frmShedule shedule)
        {
            this.shedule = shedule;
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            title = txtTitle.ToString();
            duration = int.Parse(txtDuration.ToString());
            label = txtLabel.ToString();
            this.Close();
        }
    }
}
