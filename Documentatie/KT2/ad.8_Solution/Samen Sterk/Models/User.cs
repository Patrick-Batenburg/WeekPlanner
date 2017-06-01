using LinqToDB.Mapping;

namespace SamenSterk.Models
{
    [Table(Name = "Users")]
    public class User : ModelBase
    {
        private uint id;
        private string username;
        private string password;
        private string role;

        /// <summary>
        /// Creates an empty User.
        /// </summary>
        public User()
        {
            this.role = "Member";
        }

        /// <summary>
        /// Creates a new User.
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
        /// Gets/Sets the username of the User object.
        /// </summary>
        [Column(Name = "Username"), NotNull]
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets/Sets the password of the User object.
        /// </summary>
        [Column(Name = "Password"), NotNull]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets/Sets the role of the User object.
        /// </summary>
        [Column(Name = "Role"), NotNull]
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Id");
            }
        }
    }
}