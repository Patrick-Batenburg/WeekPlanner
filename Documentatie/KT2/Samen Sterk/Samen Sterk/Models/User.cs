using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamenSterk.Models
{
    public class User
    {
        private uint id;
        private string username;
        private string password;
        private string role;

        /// <summary>
        /// Creates a new User object.
        /// </summary>
        /// <param name="username">Username of the User.</param>
        /// <param name="password">Password of the User.</param>
        /// <param name="role">Role of the User.</param>
        User(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        /// <summary>
        /// Gets/Sets the Id of the User object.
        /// </summary>
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets/Sets the Username of the User object.
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Gets/Sets the Password of the User object.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Gets/Sets the Role of the User object.
        /// </summary>
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
