using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamenSterk.Models
{
    public partial class Shedule : Form
    {
        Login login;
        bool logout;
        string cellContent = "";
        public Shedule(Login login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void dgvShedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                cellContent = dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else
            {
                cellContent = null;
            }
            if (string.IsNullOrEmpty(cellContent))
            {
                AddTask addTask = new AddTask(this);
                addTask.ShowDialog();
            }
            else
            {
                EditTask editTask = new EditTask(this);
                editTask.ShowDialog();
            }
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
