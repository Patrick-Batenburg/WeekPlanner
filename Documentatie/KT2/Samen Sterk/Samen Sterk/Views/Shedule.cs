using SamenSterk.Models;
using SamenSterk.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SamenSterk.Views
{
    public partial class Shedule : Form
    {
        private Login login;
        private bool logout;
        private int[] cellPos = new int[] { 0, 0 };
        public uint userId;
        public string title;
        public int duration;
        public string label;
        public bool repeating;
        public DateTime statDate;
        private TaskController taskController = new TaskController();
        private BindingSource bindingSource = new BindingSource();
        private List<Task> tasks = new List<Task>();
        MySqlConnection connection;

        public Shedule(Login login, uint userId)
        {
            InitializeComponent();
            this.login = login;
            this.userId = userId;
            dgvShedule.ColumnHeaderMouseClick += dgvShedule_ColumnHeaderMouseClick;
            tasks = taskController.Details(userId);

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = DateTime.Today.AddDays(i).ToString("d");
            }
        }

        //GENERAL\\

        private void Shedule_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 17; i++)
            {
                dgvShedule.Rows.Add();
                dgvShedule.Rows[i].HeaderCell.Value = (7 + i) + ":00";
            }

            LoadToGrid();
            //load tasks from database
        }

        private void LoadToGrid()
        {
            List<Task> tasks = new List<Task>();
            tasks = taskController.Details(userId);
            var load = from task in tasks select task;
            /*
            if (load != null)
            {
                dgvShedule.DataSource = load.ToList();
            }*/
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout = true;
            this.Close();
        }

        private void Shedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout == true)
            {
                login.Show();
            }
            else
            {
                login.Close();
            }
        }

        //MAIN SHEDULE\\

        private void dgvShedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //checks if it didn't touched the headers
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                cellPos = new int[] { e.RowIndex, e.ColumnIndex }; //gets the position of the selected cell
                string cellContent = "";
                if (dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    //if the cell value has content
                    cellContent = dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                else if (!dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor.IsEmpty)
                {
                    //if the cell value is empty, but is different colored
                    //look up to most upper cell with value
                    int i = 0;
                    do
                    {
                        if (dgvShedule.Rows[e.RowIndex - i].Cells[e.ColumnIndex].Value != null)
                        {
                            cellContent = dgvShedule.Rows[e.RowIndex - i].Cells[e.ColumnIndex].Value.ToString(); 
                            cellPos = new int[] { e.RowIndex, e.ColumnIndex }; //gets the position of the selected cell
                        }
                        i++;
                    }
                    while (dgvShedule.Rows[e.RowIndex - i + 1].Cells[e.ColumnIndex].Value == null);
                }
                else
                {
                    //the cell is empty.
                    cellContent = null;
                }
                if (string.IsNullOrEmpty(cellContent))
                {
                    string selectedDay = dgvShedule.Columns[e.ColumnIndex].HeaderText;
                    string selectedTime = dgvShedule.Rows[e.RowIndex].HeaderCell.Value.ToString();
                    AddTask addTask = new AddTask(this, selectedDay, selectedTime, userId);
                    addTask.ShowDialog();
                }
                else
                {
                    title = cellContent;
                    EditTask editTask = new EditTask(this, title, duration, label, repeating);
                    editTask.ShowDialog();
                }
            }
        }

        public void AddTaskToTable()
        {
            dgvShedule.Rows[cellPos[0]].Cells[cellPos[1]].Value = title;
            //gives a color with it's length depending on the duration.
            int i = 0;
            do
            {
                dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Style.BackColor = Color.Gray;
                i++;
            }
            while (cellPos[0] + i < dgvShedule.Rows.Count && i < duration);

            tasks = taskController.Details(userId);
        }

        public void DeleteTaskFromTable()
        {
            dgvShedule.Rows[cellPos[0]].Cells[cellPos[1]].Value = ""; 
            int i = 0;
            do
            {
                dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Style.BackColor = Color.Empty;
                i++;
            }
            while (dgvShedule.Rows[cellPos[0] + i].Cells[cellPos[1]].Value == null && cellPos[0] + i - 1 < dgvShedule.Rows.Count);
        }

        //GRADE LIST\\

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtColumnName.Text))
            {
                dgvGrades.Columns.Add("clm" + txtColumnName.Text, txtColumnName.Text);
                lblInsertName.Visible = false;
            }
            else
            {
                lblInsertName.Visible = true;
            }
            txtColumnName.Text = "";
        }

        private void dgvShedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvShedule_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditSchedule editSchedule = new EditSchedule(this, Convert.ToDateTime(this.dgvShedule.Columns[0].HeaderText));
            editSchedule.ShowDialog();

            for (int i = 0; i < 7; i++)
            {
                dgvShedule.Columns[i].HeaderText = statDate.AddDays(i).ToString("d");
            }
        }
    }
}
