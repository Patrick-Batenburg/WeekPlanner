using LinqToDB.Mapping;

namespace SamenSterk.Models
{
    [Table(Name = "Grades")]
    public class Grade : ModelBase
    {
        private uint userId;
        private uint rowIndex;
        private uint columnIndex;
        private float number;

        /// <summary>
        /// Creates an empty Grade.
        /// </summary>
        public Grade()
        {
        }

        /// <summary>
        /// Creates a new Grade.
        /// </summary>
        /// <param name="userId">User id of the the Grade object.</param>
        /// <param name="rowIndex">Row index of the the Grade object.</param>
        /// <param name="columnIndex">Column index of the the Grade object.</param>
        /// <param name="number">Number of the the Grade object.</param>
        public Grade(uint userId, uint rowIndex, uint columnIndex, float number)
        {
            this.userId = userId;
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            this.number = number;
        }

        /// <summary>
        /// Gets/Sets the row index of the Grade object.
        /// </summary>
        [PrimaryKey, NotNull]
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
        /// Gets/Sets the user id of the Grade object.
        /// </summary>
        [Column(Name = "UserId")]
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
        /// Gets/Sets the column index of the Grade object.
        /// </summary>
        [Column(Name = "ColumnIndex"), NotNull]
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
        [Column(Name = "Number"), NotNull]
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