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
        private float grade;

        Grade(uint userId, uint rowIndex, uint columnIndex, float grade)
        {
            this.userId = userId;
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            this.grade = grade;
        }

        public uint UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public uint RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public uint ColumnIndex
        {
            get { return columnIndex; }
            set { columnIndex = value; }
        }

        public float Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}
