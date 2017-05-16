using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamenSterk.Models
{
    public class Appointment
    {
        private uint id;
        private uint userId;
        private string description;
        private DateTime date;

        /// <summary>
        /// Initializes a new instance of the Appointment class.
        /// </summary>
        public Appointment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Appointment class.
        /// </summary>
        /// <param name="userId">User id of the the Appointment object.</param>
        /// <param name="description">Description of the the Appointment object.</param>
        /// <param name="date">Date of the the Appointment object.</param>
        public Appointment(uint userId, string description, DateTime date)
        {
            this.userId = userId;
            this.description = description;
            this.date = date;
        }

        /// <summary>
        /// Gets/Sets the id of the Appointment object.
        /// </summary>
        [PrimaryKey, Identity]
        public uint Id { get; set; }

        /// <summary>
        /// Gets/Sets the user id of the Appointment object.
        /// </summary>
        [Column(Name = "UserId"), NotNull]
        public uint UserId { get; set; }

        /// <summary>
        /// Gets/Sets the description of the Appointment object.
        /// </summary>
        [Column(Name = "Description"), NotNull]
        public string Description { get; set; }

        /// <summary>
        /// Gets/Sets the date of the Appointment object.
        /// </summary>
        [Column(Name = "Date"), NotNull]
        public DateTime Date { get; set; }
    }
}
