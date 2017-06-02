using LinqToDB;
using SamenSterkOnline.Models;

namespace SamenSterkOnline.Database
{
    internal class DataConnection : LinqToDB.Data.DataConnection
    {
        /// <summary>
        /// Initializes a new instance of the DataConnection class.
        /// </summary>
        public DataConnection() : base("TaskDatabase") { }

        public ITable<Appointment> Appointment { get { return GetTable<Appointment>(); } }
        public ITable<Grade> Grade { get { return GetTable<Grade>(); } }
        public ITable<Subject> Subject { get { return GetTable<Subject>(); } }
        public ITable<Task> Task { get { return GetTable<Task>(); } }
        public ITable<RepeatingTask> RepeatingTask { get { return GetTable<RepeatingTask>(); } }
        public ITable<User> User { get { return GetTable<User>(); } }
    }
}