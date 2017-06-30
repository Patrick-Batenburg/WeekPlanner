using LinqToDB;
using SamenSterkOnline.MySQL;
using SamenSterkOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamenSterkOnline.Controllers
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
        /// <returns>A list of subjects filled with values from the database.</returns>
        public List<Subject> Details(uint? userId)
        {
            List<Subject> subjects = new List<Subject>();

			if (userId == null)
			{
				subjects = null;
			}
			else
			{
				try
				{
					using (TaskDatabase db = new TaskDatabase())
					{
						List<Subject> query = (from subject in db.Subjects
											   where subject.UserId == userId
											   select subject).ToList();

						if (query != null)
						{
							foreach (Subject _subject in query)
							{
								subject = new Subject()
								{
									Id = _subject.Id,
									UserId = _subject.UserId,
									RowIndex = _subject.RowIndex,
									Name = _subject.Name
								};

								subjects.Add(subject);
							}
						}
					}
				}
				catch (Exception)
				{
					subjects = null;
                }
			}

            return subjects;
        }

		/// <summary>
		/// Creates a new subject.
		/// </summary>
		/// <param name="model">Subject details to create.</param>
		/// <returns>0 on subject already exists, 1 on success, 2 on unexpected database error.</returns>
		public int Create(Subject model)
        {
            int result = 0;
            List<Subject> subjects = new List<Subject>();

			if (model != null)
			{
				subjects = Details(model.UserId);
			}

			try
			{
				using (TaskDatabase db = new TaskDatabase())
				{
					Subject query = (from subject in subjects
									 where subject.Name == model.Name
									 select subject).FirstOrDefault();

					if (query == null)
					{
						result = db.Insert(model);
					}
				}
			}
			catch (Exception)
			{
				result = 2;
			}

            return result;
        }

		/// <summary>
		/// Edit an existing subject.
		/// </summary>
		/// <param name="model">Subject details to edit.</param>
		/// <returns>0 on subject already exists, 1 on success, 2 on unexpected database error.</returns>
		public int Edit(Subject model)
        {
            int result = 0;
            List<Subject> subjects = new List<Subject>();

			if (model != null)
			{
				subjects = Details(model.UserId);
			}

			try
			{
				using (TaskDatabase db = new TaskDatabase())
				{
					Subject query = (from subject in subjects
									 where subject.Name == model.Name && subject.Id != model.Id
									 select subject).FirstOrDefault();

					if (query == null)
					{
						result = db.Update(model);
					}
				}
			}
			catch (Exception)
			{
				result = 2;
			}

			return result;
        }

		/// <summary>
		/// Deletes an existing subject.
		/// </summary>
		/// <param name="model">Subject details to delete.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Delete(Subject model)
        {
            int result = 0;

			try
			{
				using (TaskDatabase db = new TaskDatabase())
				{
					result = db.Delete(model);
				}
			}
			catch (Exception)
			{
				result = 2;
			}

            return result;
        }
    }
}