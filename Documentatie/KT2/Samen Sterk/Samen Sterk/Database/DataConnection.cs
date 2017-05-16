using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamenSterk.Models;

namespace SamenSterk.Database
{
    class DataConnection : LinqToDB.Data.DataConnection
    {
        /// <summary>
        /// Initializes a new instance of the DataConnection class.
        /// </summary>
        public DataConnection() : base("TaskDB") { }

        public ITable<Appointment> Appointment { get { return GetTable<Appointment>(); } }
        public ITable<Grade> Grade { get { return GetTable<Grade>(); } }
        public ITable<Subject> Subject { get { return GetTable<Subject>(); } }
        public ITable<Task> Task { get { return GetTable<Task>(); } }
        public ITable<User> User { get { return GetTable<User>(); } }
    }
}
