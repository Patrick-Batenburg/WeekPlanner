using LinqToDB.Mapping;
using System;

namespace SamenSterk.Models
{
    [Table(Name = "Appointments")]
    public class Appointment : ModelBase
    {
        private uint id;
        private uint userId;
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
        public Appointment(uint userId, string name, DateTime date)
        {
            this.userId = userId;
            this.name = name;
            this.date = date;
        }

        /// <summary>
        /// Gets/Sets the id of the Appointment object.
        /// </summary>
        [PrimaryKey, Identity]
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
        /// Gets/Sets the user id of the Appointment object.
        /// </summary>
        [Column(Name = "UserId"), NotNull]
        public uint UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        /// <summary>
        /// Gets/Sets the description of the Appointment object.
        /// </summary>
        [Column(Name = "Name"), NotNull]
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
        [Column(Name = "Date"), NotNull]
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