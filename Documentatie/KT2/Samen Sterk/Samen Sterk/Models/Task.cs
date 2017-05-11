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

        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        public uint UserId
        {
            get { return userId }
            set { userId = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public byte Repeats
        {
            get { return repeats; }
            set { repeats = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
        }
    }
}
