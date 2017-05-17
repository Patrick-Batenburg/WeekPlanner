using MySql.Data.MySqlClient;
using SamenSterk.Database;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamenSterk.Providers;
using LinqToDB;

namespace SamenSterk.Controllers
{
    public class GradeController : ControllerBase
    {
        private Grade grade = null;

        /// <summary>
        /// Initializes a new instance of the GradeController class.
        /// </summary>
        public GradeController()
        {

        }

        /// <summary>
        /// View the details about all the grades of the specified user.
        /// </summary>
        /// <param name="userId">User id of the grade.</param>
        /// <returns>A list of grades with values from the database.</returns>
        public List<Grade> Details(uint? userId)
        {
            List<Grade> grades = null;

            if (userId == null)
            {
                grades = null;
            }

            using (var db = new DataConnection())
            {
                var query = (from grades in db.Grade
                             where grades.UserId == userId
                             select grades).ToList();

                if (query != null)
                {
                    foreach (Grade _grade in query)
                    {
                        grade = new Grade()
                        {
                            UserId = _grade.UserId,
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

            using (var db = new DataConnection())
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

            using (var db = new DataConnection())
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

            using (var db = new DataConnection())
            {
                result = db.Delete(model);
            }

            return result;
        }
    }
}
