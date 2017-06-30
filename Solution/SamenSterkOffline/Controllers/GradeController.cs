using SamenSterkOffline.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamenSterkOffline.Controllers
{
	public class GradeController
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
		/// <returns>A list of grades filled with values from the database.</returns>
		public List<Grade> Details()
		{
			List<Grade> grades = new List<Grade>();

			try
			{
                using (SQLiteConnection db = new SQLiteConnection(Program.STARTUP_PATH, SQLiteOpenFlags.ReadOnly))
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
			}
			catch (Exception)
			{
			}

			return grades;
		}

		/// <summary>
		/// Creates a new grade.
		/// </summary>
		/// <param name="model">Grade details to create.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Create(Grade model)
		{
			int result = 0;

			try
			{
                using (SQLiteConnection db = new SQLiteConnection(Program.STARTUP_PATH))
				{
					result = db.Insert(model);
				}
			}
			catch (Exception)
			{
				result = 2;
			}

			return result;
		}

		/// <summary>
		/// Edit an existing grade.
		/// </summary>
		/// <param name="model">Grade details to edit.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Edit(Grade model)
		{
			int result = 0;

			try
			{
                using (SQLiteConnection db = new SQLiteConnection(Program.STARTUP_PATH))
				{
					result = db.Update(model);
				}
			}
			catch (Exception)
			{
				result = 2;
			}

			return result;
		}

		/// <summary>
		/// Deletes an existing grade.
		/// </summary>
		/// <param name="model">Grade details to delete.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Delete(Grade model)
		{
			int result = 0;

			try
			{
                using (SQLiteConnection db = new SQLiteConnection(Program.STARTUP_PATH))
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