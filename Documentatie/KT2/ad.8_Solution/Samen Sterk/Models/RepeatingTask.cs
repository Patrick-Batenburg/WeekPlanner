using LinqToDB.Mapping;
using System;

namespace SamenSterk.Models
{
    [Table(Name = "repeatingtasks")]
    public class RepeatingTask : ModelBase
    {
        private uint id;
        private uint userId;
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
            this.title = "[Geen titel]";
            this.duration = 1;
        }

        /// <summary>
        /// Creates a new RepeatingTask.
        /// </summary>
        /// <param name="userId">User id of the the RepeatingTask object.</param>
        /// <param name="title">Title of the the RepeatingTask object.</param>
        /// <param name="day">Day of the the RepeatingTask object.</param>
        /// <param name="duration">Duration of the the RepeatingTask object.</param>
        /// <param name="label">Label of the the RepeatingTask object.</param>
        public RepeatingTask(uint userId, string title, string day, TimeSpan time, byte duration, string label = "")
        {
            this.userId = userId;
            this.title = title;
            this.day = day;
            this.time = time;
            this.duration = duration;
            this.label = label;
        }

        /// <summary>
        /// Gets/Sets the id of the RepeatingTasks object.
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
        /// Gets/Sets the user id of the RepeatingTasks object.
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
        /// Gets/Sets the title of the RepeatingTasks object.
        /// </summary>
        [Column(Name = "Title"), NotNull]
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
        [Column(Name = "Day"), NotNull]
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
        [Column(Name = "Time"), NotNull]
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
        [Column(Name = "Duration"), NotNull]
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
        [Column(Name = "Label"), Nullable]
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