using SQLite;
using System;

namespace SamenSterkOffline.Models
{
    [Table("RepeatingTasks")]
    public class RepeatingTask : ModelBase
    {
        private uint id;
        private string title;
        private string day;
        private TimeSpan time;
        private byte duration;
        private string label;

        /// <summary>
        /// Creates an empty RepeatingTask.
        /// </summary>
        public RepeatingTask()
        {
			this.id = 0;
            this.title = "[Geen titel]";
			this.day = "Monday";
			this.time = TimeSpan.MinValue;
            this.duration = 1;
			this.label = "[Geen label]";
        }

        /// <summary>
        /// Creates a new RepeatingTask.
        /// </summary>
        /// <param name="userId">User id of the the RepeatingTask object.</param>
        /// <param name="title">Title of the the RepeatingTask object.</param>
        /// <param name="day">Day of the the RepeatingTask object.</param>
        /// <param name="duration">Duration of the the RepeatingTask object.</param>
        /// <param name="label">Label of the the RepeatingTask object.</param>
        public RepeatingTask(string title, string day, TimeSpan time, byte duration, string label = "")
        {
            this.title = title;
            this.day = day;
            this.time = time;
            this.duration = duration;
            this.label = label;
        }

        /// <summary>
        /// Gets/Sets the id of the RepeatingTasks object.
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
        /// Gets/Sets the title of the RepeatingTasks object.
        /// </summary>
        [Column("Title"), NotNull, MaxLength(64)]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets/Sets the day of the RepeatingTasks object.
        /// </summary>
        [Column("Day"), NotNull, MaxLength(8)]
        public string Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        /// <summary>
        /// Gets/Sets the time of the RepeatingTasks object.
        /// </summary>
        [Column("Time"), NotNull]
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        /// <summary>
        /// Gets/Sets the duration of the RepeatingTasks object.
        /// </summary>
        [Column("Duration"), NotNull, MaxLength(2)]
        public byte Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Gets/Sets the label of the RepeatingTasks object.
        /// </summary>
        [Column("Label"), MaxLength(64)]
        public string Label
        {
            get { return label; }
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }
    }
}