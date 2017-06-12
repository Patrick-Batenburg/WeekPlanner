using SQLite;

namespace SamenSterkOffline.Models
{
    [Table("Grades")]
    public class Grade : ModelBase
    {
        private uint id;
        private uint rowIndex;
        private uint columnIndex;
        private float number;

        /// <summary>
        /// Creates an empty Grade.
        /// </summary>
        public Grade()
        {
            this.rowIndex = 0;
            this.columnIndex = 0;
            this.number = 1.0f;
        }

        /// <summary>
        /// Creates a new Grade.
        /// </summary>
        /// <param name="userId">User id of the the Grade object.</param>
        /// <param name="rowIndex">Row index of the the Grade object.</param>
        /// <param name="columnIndex">Column index of the the Grade object.</param>
        /// <param name="number">Number of the the Grade object.</param>
        public Grade(uint rowIndex, uint columnIndex, float number)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            this.number = number;
        }

        /// <summary>
        /// Gets/Sets the row index of the Grade object.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public uint Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("RowIndex");
            }
        }

        /// <summary>
        /// Gets/Sets the row index of the Grade object.
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
        /// Gets/Sets the column index of the Grade object.
        /// </summary>
        [Column("ColumnIndex"), NotNull]
        public uint ColumnIndex
        {
            get { return columnIndex; }
            set
            {
                columnIndex = value;
                OnPropertyChanged("ColumnIndex");
            }
        }

        /// <summary>
        /// Gets/Sets the number of the Grade object.
        /// </summary>
        [Column("Number"), NotNull, MaxLength(2)]
        public float Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
    }
}