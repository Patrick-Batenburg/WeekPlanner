using SamenSterkOffline.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamenSterkOffline.Controllers
{
	public class RepeatingTaskController
	{
		private RepeatingTask repeatingTask = null;

		/// <summary>
		/// Initializes a new instance of the TaskController class.
		/// </summary>
		public RepeatingTaskController()
		{
		}

		/// <summary>
		/// View the details about all the repeating tasks of the specified user.
		/// </summary>
		/// <param name="userId">User id of the task.</param>
		/// <returns>A list of repeating tasks filled with values from the database.</returns>
		public List<RepeatingTask> Details()
		{
			List<RepeatingTask> repeatingTasks = new List<RepeatingTask>();

			try
			{
				using (SQLiteConnection db = new SQLiteConnection(Program.STARTUP_PATH, SQLiteOpenFlags.ReadOnly))
				{
					List<RepeatingTask> query = (from repeatingTask in db.Table<RepeatingTask>()
												 select repeatingTask).ToList();

					if (query != null)
					{
						foreach (RepeatingTask _repeatingTask in query)
						{
							repeatingTask = new RepeatingTask()
							{
								Id = _repeatingTask.Id,
								Title = _repeatingTask.Title,
								Day = _repeatingTask.Day,
								Time = _repeatingTask.Time,
								Duration = _repeatingTask.Duration,
								Label = _repeatingTask.Label
							};

							repeatingTasks.Add(repeatingTask);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			
			return repeatingTasks;
		}

		/// <summary>
		/// Creates a new repeating task.
		/// </summary>
		/// <param name="model">Repeating task details to create.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Create(RepeatingTask model)
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
		/// Edit an existing repeating task.
		/// </summary>
		/// <param name="model">Repeating task details to edit.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Edit(RepeatingTask model)
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
		/// Checks if an existing repeating task exceeds another repeating task or task.
		/// </summary>
		/// <param name="model">Repeating task details to check on.</param>
		/// <returns>0 on nothing exceeds, 3 on DateTime exceeds, 2 on unexpected database error.</returns>
		public int Exceeds(RepeatingTask model)
		{
			int result = 0;
			int[] totalrecords = new int[4];
			TaskController taskController = new TaskController();
			List<RepeatingTask> repeatingTasks = new List<RepeatingTask>();
			List<Task> tasks = new List<Task>();

			if (model != null)
			{
				repeatingTasks = Details();
				tasks = taskController.Details();
			}

			try
			{
				using (SQLiteConnection db = new SQLiteConnection(Program.STARTUP_PATH))
				{
					List<RepeatingTask> repeatingTaskQuery = (from repeatingTask in repeatingTasks
															  where repeatingTask.Day == model.Day && repeatingTask.Id != model.Id
															  select repeatingTask).ToList();

					List<RepeatingTask> repeatingTaskDate = (from repeatingTask in repeatingTaskQuery
															 where repeatingTask.Time.Add(new TimeSpan(repeatingTask.Duration - 1, 0, 0)) < model.Time
															 select repeatingTask).ToList();

					totalrecords[0] = repeatingTaskDate.Count;

					repeatingTaskDate = (from repeatingTask in repeatingTaskQuery
										 where repeatingTask.Time > new TimeSpan(model.Time.Hours + model.Duration - 1, 0, 0)
										 select repeatingTask).ToList();

					totalrecords[1] = repeatingTaskDate.Count;

					if (repeatingTaskQuery.Count != totalrecords[0] + totalrecords[1])
					{
						result = 3;
					}
					else
					{
						List<Task> taskQuery = (from task in tasks
												where task.Date.ToString("dddd") == model.Day
												select task).ToList();

						List<Task> taskDate = (from task in taskQuery
											   where task.Date.AddHours(task.Duration - 1) < new DateTime(task.Date.Year, task.Date.Month, task.Date.Day, 0, 0, 0).Add(model.Time)
											   select task).ToList();

						totalrecords[2] = taskDate.Count;

						taskDate = (from task in taskQuery
									where task.Date > new DateTime(task.Date.Year, task.Date.Month, task.Date.Day, 0, 0, 0).Add(model.Time).AddHours(model.Duration - 1)
									select task).ToList();

						totalrecords[3] = taskDate.Count;

						if (taskQuery.Count != totalrecords[2] + totalrecords[3])
						{
							result = 3;
						}
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
		/// Deletes an existing repeating task.
		/// </summary>
		/// <param name="model">Repeating task details to delete.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Delete(RepeatingTask model)
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