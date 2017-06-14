using SamenSterkOffline.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamenSterkOffline.Controllers
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
        public List<Subject> Details()
        {
            List<Subject> subjects = new List<Subject>();

			try
			{
				using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
				{
					List<Subject> query = (from subject in db.Table<Subject>()
										   select subject).ToList();

					if (query != null)
					{
						foreach (Subject _subject in query)
						{
							subject = new Subject()
							{
								Id = _subject.Id,
								RowIndex = _subject.RowIndex,
								Name = _subject.Name
							};

							subjects.Add(subject);
						}
					}
				}
			}
			catch (System.Exception)
			{
				subjects = null;
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
				subjects = Details();
			}

			try
			{
				using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
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
		/// <returns>0 on failure, 1 on success, 2 on subject already exists.</returns>
		public int Edit(Subject model)
		{
			int result = 0;
			List<Subject> subjects = new List<Subject>();

			if (model != null)
			{
				subjects = Details();
			}

			try
			{
				using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
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
				using (SQLiteConnection db = new SQLiteConnection(Program.DB_PATH))
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