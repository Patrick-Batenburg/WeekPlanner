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
    public partial class AddTask : Form
    {
        Shedule shedule;
        public AddTask(Shedule shedule)
        {
            this.shedule = shedule;
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            shedule.title = txtTitle.Text;
            shedule.duration = Convert.ToByte(nudDuration.Value);
            shedule.label = txtLabel.Text;
            shedule.AddTaskToTable();
            this.Close();
        }
    }
}
