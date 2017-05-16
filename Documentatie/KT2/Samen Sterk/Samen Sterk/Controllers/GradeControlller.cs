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
    public class GradeController
    {
        private Grade grade = null;
        private List<Grade> grades = new List<Grade>();

        public int Details(uint? id)
        {
            int result = 0;

            return result;
        }

        public int Create(Grade model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                var query = (from grade in db.Grade
                             where grade.RowIndex == model.RowIndex && grade.ColumnIndex == model.ColumnIndex
                             select grade).SingleOrDefault();

                if (query != null)
                {
                    result = 1;
                }
            }

            return result;
        }

        public int Edit(Grade model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Update(model);
            }

            return result;
        }

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
