using System;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class EditSchedule : Form
    {
        private Shedule shedule;
        private DateTime date;

        public EditSchedule(Shedule shedule, DateTime date)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.date = date;
            startDateTimePicker.Value = Convert.ToDateTime(date);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            shedule.startDate = startDateTimePicker.Value;
            this.Close();
        }
    }
}