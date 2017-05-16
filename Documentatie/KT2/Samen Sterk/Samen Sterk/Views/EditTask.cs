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
    public partial class EditTask : Form
    {
        Shedule shedule;
        public EditTask(Shedule shedule, string title, int duration, string label, bool repeating)
        {
            InitializeComponent();
            txtTitle.Text = title;
            nudDuration.Value = duration;
            txtLabel.Text = label;
            cbRepeating.Checked = repeating;
            this.shedule = shedule;
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            shedule.title = txtTitle.Text;
            shedule.duration = Convert.ToByte(nudDuration.Value);
            shedule.label = txtLabel.Text;
            shedule.AddTaskToTable();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet je het zeker?", "Taak verwijderen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                shedule.DeleteTaskFromTable();
                this.Close();
            }
        }
    }
}
