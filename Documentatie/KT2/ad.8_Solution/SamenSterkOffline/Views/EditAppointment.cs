using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamenSterkOffline.Views
{
    public partial class EditAppointment : Form
    {
        private Shedule shedule;
        private DateTime date;

        /// <summary>
        /// Initializes a new instance of the form EditAppointment class.
        /// </summary>
        /// <param name="shedule">Shedule form details to edit.</param>
        /// <param name="date">Date of first date in the DataGridView.</param>
        public EditAppointment(Shedule shedule, DateTime date)
        {
            InitializeComponent();
            this.shedule = shedule;
            this.date = date;
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm";
            datePicker.Value = date;
            timePicker.Value = date;
        }

        /// <summary>
        /// Occurs when the Value property changes. Changes the value of the selected date to the date of today if it's less than the date of today.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            if (datePicker.Value < DateTime.Today)
            {
                datePicker.Value = DateTime.Today;
            }
        }

        /// <summary>
        /// Occurs when the Value property changes. Changes the value of the selected time to the time of now if it's less than the time of now.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            if (timePicker.Value < DateTime.Now)
            {
                timePicker.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// Occurs when the Button control is clicked. Edit the date of the Appointment. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (datePicker.Value < DateTime.Today)
            {
                datePicker.Value = DateTime.Today;
            }

            if (timePicker.Value < DateTime.Now)
            {
                timePicker.Value = DateTime.Now;
            }

            shedule.appointmentDate = datePicker.Value.Date + timePicker.Value.TimeOfDay;
            shedule.EditAppointment();
            this.Close();
        }

        /// <summary>
        /// Occurs when the Button control is clicked. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param> 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
