using SamenSterkOnline.Controllers;
using SamenSterkOnline.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SamenSterkOnline.Views
{
    public partial class DeleteUsers : Form
    {
        private User user;
        private List<User> users;
        private List<Task> tasks;
        private List<RepeatingTask> repeatingTasks;
        private List<Grade> grades;
        private List<Subject> subjects;
        private List<Appointment> appointments;

        private UserController userController;
        private TaskController taskController;
        private RepeatingTaskController repeatingTaskController;
        private GradeController gradeController;
        private SubjectController subjectController;
        private AppointmentController appointmentController;

        /// <summary>
        /// Initializes a new instance of the form DeleteUsers class.
        /// </summary>
        /// <param name="user">User details to extract.</param>
        public DeleteUsers(User user)
        {
            InitializeComponent();
			if (user != null)
			{
				this.user = user;
			}
			userController = new UserController();
            taskController = new TaskController();
            repeatingTaskController = new RepeatingTaskController();
            gradeController = new GradeController();
            subjectController = new SubjectController();
            appointmentController = new AppointmentController();
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadToGrid();
        }

        /// <summary>
        /// Loads all the users into the DataGridView.
        /// </summary>
        public void LoadToGrid()
        {
            DataTable dataTable = new DataTable();

            dgvUsers.CellValueChanged -= dgvUsers_CellValueChanged;
            dgvUsers.DataSource = null;
            dgvUsers.Rows.Clear();
            users = userController.Details(user);

            dataTable.Columns.Add("Gebruikersnaam", typeof(string));
            dataTable.Columns.Add("Verwijderen?", typeof(bool));
            dataTable.Columns.Add("Id", typeof(uint));

            if (users.Count != 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    dataTable.Rows.Add(users[i].Username, false, users[i].Id);
                }
            }

            dgvUsers.DataSource = dataTable;
            dgvUsers.Columns[1].Resizable = DataGridViewTriState.False;
            dgvUsers.Columns[2].Resizable = DataGridViewTriState.False;
            dgvUsers.Columns[dgvUsers.ColumnCount - 1].Visible = false;
            dgvUsers.Columns[0].ReadOnly = true; 
            dgvUsers.CellValueChanged += dgvUsers_CellValueChanged;
        }

        /// <summary>
        /// Occurs when the user releases a mouse button while over a cell. Exits edit mode of the cell.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        private void dgvUsers_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgvUsers.EndEdit();
            }
        }

        /// <summary>
        /// Occurs when the value of a cell changes. Adds a new Appointment if there wasn't no value. Edit an existing Appointment if the value changed. Deletes an existing Appointment if the value is empty.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.CellValueChanged -= dgvUsers_CellValueChanged;
            dgvUsers[e.ColumnIndex, e.RowIndex].Value = false;
            dgvUsers.CellValueChanged += dgvUsers_CellValueChanged;

            if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("U staat op het punt om deze gebruiker te verwijderen.\nAlle taken, vakken, cijfers en afspraken zullen van deze gebruiker verwijderd worden.", "Gebruiker verwijderen", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    int result = 0;
                    User query = null;
                    uint? id = null;

                    List<DataGridViewRow> rows = (from row in dgvUsers.Rows.Cast<DataGridViewRow>()
                                                  select row).ToList();

                    id = (from row in rows
                          where Convert.ToBoolean(row.Cells["verwijderen?"].Value) == true
                          select Convert.ToUInt32(row.Cells[dgvUsers.ColumnCount - 1].Value)).FirstOrDefault();

                    query = (from user in users
                             where user.Id == id
                             select user).FirstOrDefault();

                    if (query != null)
                    {
                        tasks = taskController.Details(id);
                        repeatingTasks = repeatingTaskController.Details(id);
                        grades = gradeController.Details(id);
                        subjects = subjectController.Details(id);
                        appointments = appointmentController.Details(id);

                        for (int i = 0; i < tasks.Count; i++)
                        {
                            taskController.Delete(tasks[i]);
                        }

                        for (int i = 0; i < repeatingTasks.Count; i++)
                        {
                            repeatingTaskController.Delete(repeatingTasks[i]);
                        }

                        for (int i = 0; i < grades.Count; i++)
                        {
                            gradeController.Delete(grades[i]);
                        }

                        for (int i = 0; i < subjects.Count; i++)
                        {
                            subjectController.Delete(subjects[i]);
                        }

                        for (int i = 0; i < appointments.Count; i++)
                        {
                            appointmentController.Delete(appointments[i]);
                        }

                        result = userController.Delete(query);

                        if (result == 0)
                        {
                            MessageBox.Show("Kon de gebruiker niet verwijderen.");
                        }
                        else
                        {
                            MessageBox.Show("De gebruiker is succesvol verwijderd.");
                        }
                    }

                    LoadToGrid();
                }
            }
        }
    }
}