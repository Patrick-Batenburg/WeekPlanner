using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamenSterk.Models
{
    public partial class EditTask : Form
    {
        Shedule shedule;
        public EditTask(Shedule shedule)
        {
            this.shedule = shedule;
            InitializeComponent();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
