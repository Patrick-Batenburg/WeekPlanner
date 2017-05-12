using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamenSterk.Models
{
    public class Task
    {
        private uint id;
        private uint userId;
        private string title;
        private DateTime date;
        private TimeSpan duration;
        private byte repeats;
        private string label;

        /// <summary>
        /// Creates a new Task object.
        /// </summary>
        /// <param name="userId">UserId of the the Task.</param>
        /// <param name="title">Title of the the Task.</param>
        /// <param name="date">Date of the the Task.</param>
        /// <param name="duration">Duration of the the Task.</param>
        /// <param name="repeats">Repeats of the the Task.</param>
        /// <param name="label">Label of the the Task.</param>
        Task(uint userId, string title, DateTime date, TimeSpan duration, byte repeats, string label)
        {
            this.userId = userId;
            this.title = title;
            this.date = date;
            this.duration = duration;
            this.repeats = repeats;
            this.label = label;
        }

        /// <summary>
        /// Gets/Sets the Id of the Task object.
        /// </summary>
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets/Sets the UserId of the Task object.
        /// </summary>
        public uint UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// Gets/Sets the Title of the Task object.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Gets/Sets the Date of the Task object.
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Gets/Sets the Duration of the Task object.
        /// </summary>
        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        /// <summary>
        /// Gets/Sets the Repeats of the Task object.
        /// </summary>
        public byte Repeats
        {
            get { return repeats; }
            set { repeats = value; }
        }

        /// <summary>
        /// Gets/Sets the Label of the Task object.
        /// </summary>
        public string Label
        {
            get { return label; }
            set { label = value; }
        }
    }
}
