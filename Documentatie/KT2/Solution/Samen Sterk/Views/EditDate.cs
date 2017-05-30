using System;
using System.Windows.Forms;

namespace SamenSterk.Views
{
    public partial class EditDate : Form
    {
        private Shedule shedule;
        private DateTime date;

        /// <summary>
        /// Initializes a new instance of the form EditSchedule class.
        /// </summary>
        /// <param name="shedule">Shedule form details to edit.</param>
        /// <param name="date">Date of first date in the DataGridView.</param>
        public EditDate(Shedule shedule, DateTime date)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.date = date;
            startDateTimePicker.Value = date;
        }

        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value < DateTime.Today)
            {
                startDateTimePicker.Value = DateTime.Today;
            }
        }

        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            shedule.startDate = date;
            this.Close();
        }


        /// <summary>
        /// Occurs when the Button control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value < DateTime.Today)
            {
                startDateTimePicker.Value = DateTime.Today;
            }
            shedule.startDate = startDateTimePicker.Value;

            shedule.SetHeaderDate();
            this.Close();
        }
    }
}