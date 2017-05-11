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
    public partial class Shedule : Form
    {
        Login login;
        bool logout;
        string cellContent = "";
        int[] cellPos = new int[] { 0, 0 };

        public string title;
        public int duration;
        public string label;
        public bool repeating;
        public Shedule(Login login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void dgvShedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    cellContent = dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                else
                {
                    cellContent = null;
                }
                cellPos[0] = e.RowIndex;
                cellPos[1] = e.ColumnIndex;
                if (string.IsNullOrEmpty(cellContent))
                {
                    AddTask addTask = new AddTask(this);
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
    }
}
