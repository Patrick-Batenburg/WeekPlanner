using MySql.Data.MySqlClient;
using SamenSterk.Database;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamenSterk.Providers;
using LinqToDB;

namespace SamenSterk.Controllers
{
    public class TaskController
    {
        private Task task = null;

        /// <summary>
        /// Initializes a new instance of the TaskController class.
        /// </summary>
        public TaskController()
        {

        }

        /// <summary>
        /// View the details about all the tasks of the specified user.
        /// </summary>
        /// <param name="userId">User id of the task.</param>
        /// <returns>A list of tasks with values from the database.</returns>
        public List<Task> Details(uint? userId)
        {
            List<Task> tasks = null;

            if (userId == null)
            {
                tasks = null;
            }

            using (var db = new DataConnection())
            {
                var query = (from task in db.Task
                             where task.UserId == userId
                             select task).ToList();

                if (query != null)
                {
                    foreach (Task _task in query)
                    {
                        task = new Task()
                        {
                            Id = _task.Id,
                            UserId = _task.UserId,
                            Title = _task.Title,
                            Date = _task.Date,
                            Duration = _task.Duration,
                            Repeats = _task.Repeats,
                            Label = _task.Label
                        };

                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="model">Task details to create.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Create(Task model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Insert(model);
            }

            return result;
        }

        /// <summary>
        /// Edit an existing task.
        /// </summary>
        /// <param name="model">Task details to edit.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Edit(Task model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Update(model);
            }

            return result;
        }

        /// <summary>
        /// Deletes an existing task.
        /// </summary>
        /// <param name="model">Task details to delete.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Delete(Task model)
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
