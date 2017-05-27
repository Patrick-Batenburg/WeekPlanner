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
            startDateTimePicker.Value = date;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            shedule.startDate = date;
            this.Close();
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value < DateTime.Today)
            {
                startDateTimePicker.Value = DateTime.Today;
            }
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value < DateTime.Today)
            {
                startDateTimePicker.Value = DateTime.Today;
            }

            shedule.startDate = startDateTimePicker.Value;
            this.Close();
        }
    }
}