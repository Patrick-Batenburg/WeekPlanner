using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace SamenSterk.Models
{
    public class User
    {
        private uint id;
        private string username;
        private string password;
        private string role;

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        /// <param name="username">Username of the User object.</param>
        /// <param name="password">Password of the User object.</param>
        /// <param name="role">Role of the User object.</param>
        public User(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        /// <summary>
        /// Gets/Sets the id of the User object.
        /// </summary>
        [PrimaryKey, Identity]
        public uint Id { get; set; }

        /// <summary>
        /// Gets/Sets the username of the User object.
        /// </summary>
        [Column(Name = "Username"), NotNull]
        public string Username { get; set; }

        /// <summary>
        /// Gets/Sets the password of the User object.
        /// </summary>
        [Column(Name = "Password"), NotNull]
        public string Password { get; set; }

        /// <summary>
        /// Gets/Sets the role of the User object.
        /// </summary>
        [Column(Name = "Role"), NotNull]
        public string Role { get; set; }
    }
}
