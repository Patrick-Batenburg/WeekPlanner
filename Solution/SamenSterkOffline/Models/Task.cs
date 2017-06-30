using SQLite;
using System;

namespace SamenSterkOffline.Models
{
	[Table("Tasks")]
	public class Task : ModelBase
	{
		private uint id;
		private string title;
		private DateTime date;
		private byte duration;
		private string label;

		/// <summary>
		/// Creates an empty Task.
		/// </summary>
		public Task()
		{
			this.id = 0;
			this.title = "[Geen titel]";
			this.date = DateTime.MinValue;
			this.duration = 1;
			this.label = "[Geen label]";
		}

		/// <summary>
		/// Creates a new Task.
		/// </summary>
		/// <param name="userId">User id of the the Task object.</param>
		/// <param name="title">Title of the the Task object.</param>
		/// <param name="date">Date of the the Task object.</param>
		/// <param name="duration">Duration of the the Task object.</param>
		/// <param name="repeats">Repeating of the the Task object, 0 is false and 1 or above is true. Default value is 0.</param>
		/// <param name="label">Label of the the Task object.</param>
		public Task(string title, DateTime date, byte duration, string label = "")
		{
			this.title = title;
			this.date = date;
			this.duration = duration;
			this.label = label;
		}

		/// <summary>
		/// Gets/Sets the id of the Task object.
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
		/// Gets/Sets the title of the Task object.
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
		/// Gets/Sets the date of the Task object.
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

		/// <summary>
		/// Gets/Sets the duration of the Task object.
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
		/// Gets/Sets the label of the Task object.
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
