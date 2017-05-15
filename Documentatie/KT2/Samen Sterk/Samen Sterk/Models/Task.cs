using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace SamenSterk.Models
{
    [Table(Name = "Tasks")]
    public class Task
    {
        private uint id;
        private uint userId;
        private string title;
        private DateTime date;
        private byte duration;
        private byte repeats;
        private string label;

        /// <summary>
        /// Initializes a new instance of the Task class.
        /// </summary>
        /// <param name="userId">User id of the the Task object.</param>
        /// <param name="title">Title of the the Task object.</param>
        /// <param name="date">Date of the the Task object.</param>
        /// <param name="duration">Duration of the the Task object.</param>
        /// <param name="repeats">Repeating of the the TaskMeta object, 0 is false and 1 or above is true. Default value is 0.</param>
        /// <param name="label">Label of the the Task object.</param>
        public Task(uint userId, string title, DateTime date, byte duration, byte repeats, string label = "")
        {
            this.userId = userId;
            this.title = title;
            this.date = date;
            this.duration = duration;
            this.repeats = repeats;
            this.label = label;
        }

        /// <summary>
        /// Gets/Sets the id of the Task object.
        /// </summary>
        [PrimaryKey, Identity]
        public uint Id { get; set; }

        /// <summary>
        /// Gets/Sets the user id of the Task object.
        /// </summary>
        [Column(Name = "UserId"), NotNull]
        public uint UserId { get; set; }

        /// <summary>
        /// Gets/Sets the title of the Task object.
        /// </summary>
        [Column(Name = "Title"), NotNull]
        public string Title { get; set; }

        /// <summary>
        /// Gets/Sets the date of the Task object.
        /// </summary>
        [Column(Name = "Date"), NotNull]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets/Sets the duration of the Task object.
        /// </summary>
        [Column(Name = "Duration"), NotNull]
        public byte Duration { get; set; }

        /// <summary>
        /// Gets/Sets the repeating of the TaskMeta object.
        /// </summary>
        [Column(Name = "Repeats"), NotNull]
        public byte Repeats { get; set; }

        /// <summary>
        /// Gets/Sets the label of the Task object.
        /// </summary>
        [Column(Name = "Label"), Nullable]
        public string Label { get; set; }
    }
}
