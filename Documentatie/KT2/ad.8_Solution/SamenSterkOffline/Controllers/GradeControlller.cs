﻿using SamenSterkOffline.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace SamenSterkOffline.Controllers
{
    public class GradeController : ControllerBase
    {
        private Grade grade;

        /// <summary>
        /// Initializes a new instance of the GradeController class.
        /// </summary>
        public GradeController()
        {
            grade = null;
        }

        /// <summary>
        /// View the details about all the grades of the specified user.
        /// </summary>
        /// <param name="userId">User id of the grade.</param>
        /// <returns>A list of grades filled with values from the database.</returns>
        public List<Grade> Details()
        {
            List<Grade> grades = new List<Grade>();

            using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
            {
                List<Grade> query = (from grade in db.Table<Grade>()
                                     select grade).ToList();

                if (query != null)
                {
                    foreach (Grade _grade in query)
                    {
                        grade = new Grade()
                        {
                            Id = _grade.Id,
                            RowIndex = _grade.RowIndex,
                            ColumnIndex = _grade.ColumnIndex,
                            Number = _grade.Number
                        };

                        grades.Add(grade);
                    }
                }
            }

            return grades;
        }

        /// <summary>
        /// Creates a new grade.
        /// </summary>
        /// <param name="model">Grade details to create.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Create(Grade model)
        {
            int result = 0;

            using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
            {
                result = db.Insert(model);
            }

            return result;
        }

        /// <summary>
        /// Edit an existing grade.
        /// </summary>
        /// <param name="model">Grade details to edit.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Edit(Grade model)
        {
            int result = 0;

            using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
            {
                result = db.Update(model);
            }

            return result;
        }

        /// <summary>
        /// Deletes an existing grade.
        /// </summary>
        /// <param name="model">Grade details to delete.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Delete(Grade model)
        {
            int result = 0;

            using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
            {
                result = db.Delete(model);
            }

            return result;
        }
    }
}