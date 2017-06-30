using LinqToDB;
using SamenSterkOnline.Models;

namespace SamenSterkOnline.MySQL
{
    internal class TaskDatabase : LinqToDB.Data.DataConnection
    {
        /// <summary>
        /// Initializes a new instance of the DataConnection class.
        /// </summary>
        public TaskDatabase() : base("TaskDatabase") { }
		
        public ITable<Appointment> Appointments { get { return GetTable<Appointment>(); } }
        public ITable<Grade> Grades { get { return GetTable<Grade>(); } }
        public ITable<Subject> Subjects { get { return GetTable<Subject>(); } }
        public ITable<Task> Tasks { get { return GetTable<Task>(); } }
        public ITable<RepeatingTask> RepeatingTasks { get { return GetTable<RepeatingTask>(); } }
        public ITable<User> Users { get { return GetTable<User>(); } }
    }
}