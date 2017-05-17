using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamenSterk.Models;
using SamenSterk.Database;
using LinqToDB;

namespace SamenSterk.Controllers
{
    public class SubjectController
    {
        private Subject subject;

        /// <summary>
        /// Initializes a new instance of the SubjectController class.
        /// </summary>
        public SubjectController()
        {

        }

        /// <summary>
        /// View the details about all the subjects of the specified user.
        /// </summary>
        /// <param name="userId">User id of the subject.</param>
        /// <returns>A list of subjects with values from the database.</returns>
        public List<Subject> Details(uint? userId)
        {
            List<Subject> subjects = null;

            if (userId == null)
            {
                subjects = null;
            }

            using (var db = new DataConnection())
            {
                var query = (from subjects in db.Subject
                             where subjects.UserId == userId
                             select subjects).ToList();

                if (query != null)
                {
                    foreach (Subject _subject in query)
                    {
                        subject = new Subject()
                        {
                            UserId = _subject.UserId,
                            RowIndex = _subject.RowIndex,
                            Name = _subject.Name
                        };

                        subjects.Add(subject);
                    }
                }
            }

            return subjects;
        }

        /// <summary>
        /// Creates a new subject.
        /// </summary>
        /// <param name="model">Subject details to create.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Create(Subject model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Insert(model);
            }

            return result;
        }

        /// <summary>
        /// Edit an existing subject.
        /// </summary>
        /// <param name="model">Subject details to edit.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Edit(Subject model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Update(model);
            }

            return result;
        }

        /// <summary>
        /// Deletes an existing subject.
        /// </summary>
        /// <param name="model">Subject details to delete.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Delete(Subject model)
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
