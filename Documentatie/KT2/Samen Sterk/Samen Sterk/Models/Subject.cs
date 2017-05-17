﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace SamenSterk.Models
{
    [Table(Name = "Subjects")]
    public class Subject : ModelBase
    {
        private uint userId;
        private uint rowIndex;
        private string name;

        /// <summary>
        /// Creates an empty Subject.
        /// </summary>
        public Subject()
        {

        }

        /// <summary>
        /// Creates a new Subject.
        /// </summary>
        /// <param name="userId">User id of the the Subject object.</param>
        /// <param name="rowIndex">Row index of the the Subject object.</param>
        /// <param name="name">Name of the the Subject object.</param>
        public Subject(uint userId, uint rowIndex, string name)
        {
            this.userId = userId;
            this.rowIndex = rowIndex;
            this.name = name;
        }

        /// <summary>
        /// Gets/Sets the user id of the Subject object.
        /// </summary>
        [PrimaryKey]
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
        /// Gets/Sets the row index of the Subject object.
        /// </summary>
        [Column(Name = "RowIndex"), NotNull]
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
        [Column(Name = "Name"), NotNull]
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
