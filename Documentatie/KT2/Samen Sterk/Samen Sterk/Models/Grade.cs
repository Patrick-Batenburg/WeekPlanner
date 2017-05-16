using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamenSterk.Models
{
    public class Grade
    {
        private uint userId;
        private uint rowIndex;
        private uint columnIndex;
        private float number;

        /// <summary>
        /// Initializes a new instance of the Grade class.
        /// </summary>
        public Grade()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Grade class.
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
        /// Gets/Sets the user id of the Grade object.
        /// </summary>
        [PrimaryKey]
        public uint UserId { get; set; }

        /// <summary>
        /// Gets/Sets the row index of the Grade object.
        /// </summary>
        [Column(Name = "RowIndex"), NotNull]
        public uint RowIndex { get; set; }

        /// <summary>
        /// Gets/Sets the column index of the Grade object.
        /// </summary>
        [Column(Name = "ColumnIndex"), NotNull]
        public uint ColumnIndex { get; set; }

        /// <summary>
        /// Gets/Sets the number of the Grade object.
        /// </summary>
        [Column(Name = "Number"), NotNull]
        public float Number { get; set; }
    }
}
