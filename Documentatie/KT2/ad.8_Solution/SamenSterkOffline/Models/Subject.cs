using SQLite;

namespace SamenSterkOffline.Models
{
    [Table("Subjects")]
    public class Subject : ModelBase
    {
        private uint id;
        private uint rowIndex;
        private string name;

        /// <summary>
        /// Creates an empty Subject.
        /// </summary>
        public Subject()
        {
            this.rowIndex = 0;
            this.name = "[Geen naam]";
        }

        /// <summary>
        /// Creates a new Subject.
        /// </summary>
        /// <param name="userId">User id of the the Subject object.</param>
        /// <param name="rowIndex">Row index of the the Subject object.</param>
        /// <param name="name">Name of the the Subject object.</param>
        public Subject(uint rowIndex, string name)
        {
            this.rowIndex = rowIndex;
            this.name = name;
        }

        /// <summary>
        /// Gets/Sets the id of the Subject object.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets/Sets the row index of the Subject object.
        /// </summary>
        [Column("RowIndex"), NotNull]
        public uint RowIndex
        {
            get { return rowIndex; }
            set
            {
                rowIndex = value;
                OnPropertyChanged("RowIndex");
            }
        }

        /// <summary>
        /// Gets/Sets the name of the Subject object.
        /// </summary>
        [Column("Name"), NotNull, MaxLength(64)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}