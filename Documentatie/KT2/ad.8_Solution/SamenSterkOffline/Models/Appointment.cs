using SQLite;
using System;

namespace SamenSterkOffline.Models
{
    [Table("Appointments")]
    public class Appointment : ModelBase
    {
        private uint id;
        private string name;
        private DateTime date;

        /// <summary>
        /// Creates an empty Appointment.
        /// </summary>
        public Appointment()
        {
            this.name = "[Geen naam]";
            this.date = new DateTime(1980, 1, 1);
        }

        /// <summary>
        /// Creates a new Appointment.
        /// </summary>
        /// <param name="userId">User id of the the Appointment object.</param>
        /// <param name="description">Description of the the Appointment object.</param>
        /// <param name="date">Date of the the Appointment object.</param>
        public Appointment(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
        }

        /// <summary>
        /// Gets/Sets the id of the Appointment object.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public uint Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets/Sets the description of the Appointment object.
        /// </summary>
        [Column("Name"), NotNull, MaxLength(64)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets/Sets the date of the Appointment object.
        /// </summary>
        [Column("Date"), NotNull]
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
    }
}