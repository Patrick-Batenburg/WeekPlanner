using SamenSterk.Controllers;
using SamenSterk.Models;
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
    public partial class EditSubject : Form
    {
        private Subject model;
        private List<Grade> grades;
        private List<Subject> subjects;
        private GradeController gradeController;
        private SubjectController subjectController;

        public EditSubject(Subject model)
        {
            InitializeComponent();
            this.model = model;
            subjectController = new SubjectController();
            gradeController = new GradeController();
            grades = gradeController.Details(model.UserId);
            subjects = subjectController.Details(model.UserId);
            txtName.Text = model.Name; 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int result = 0;

            List<Grade> gradeQuery = (from grade in grades
                                      where grade.RowIndex == model.RowIndex 
                                      select grade).ToList();

            List<Subject> subjectQuery = (from subject in subjects
                                          where subject.RowIndex > model.RowIndex
                                          select subject).ToList();

            if (gradeQuery.Count != 0)
            {
                for (int i = 0; i < gradeQuery.Count - 1; i++)
                {
                    gradeController.Delete(grades[i]);
                }
            }

            if (subjectQuery.Count != 0)
            {
                for (int i = 0; i < subjectQuery.Count; i++)
                {
                    subjectQuery[i].RowIndex -= 1;
                    subjectController.Edit(subjectQuery[i]);
                }
            }

            result = subjectController.Delete(model);

            if (result != 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Onbekend probleem bij het verwijderen van het vak.");
            }
        }

        private void btnEditSubject_Click(object sender, EventArgs e)
        {
            this.model.Name = txtName.Text;
            int result = subjectController.Edit(model);

            if (result == 2)
            {
                MessageBox.Show("Er bestaat al een vak met dezelfde naam.");
            }

            this.Close();
        }
    }
}
