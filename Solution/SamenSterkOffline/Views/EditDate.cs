using System;
using System.Windows.Forms;

namespace SamenSterkOffline.Views
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
		/// Occurs when the Value property changes. Changes the value of the selected date to the date of today if it's less than the date of today.
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
		/// Occurs when the Button control is clicked. Saves the selected date. Closes the form.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			shedule.startDate = date;
			this.Close();
		}

		/// <summary>
		/// Occurs when the Button control is clicked. Saves the selected date and edit the DataGridView headers from the selected date. Closes the form.
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