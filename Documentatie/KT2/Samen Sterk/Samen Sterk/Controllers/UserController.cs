using LinqToDB;
using SamenSterk.Database;
using SamenSterk.Models;
using SamenSterk.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SamenSterk.Controllers
{
    public class UserController : ControllerBase
    {
        private User user = null;

        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// </summary>
        public UserController()
        {
        }

        /// <summary>
        /// View the details about all the users.
        /// </summary>
        /// <param name="model">Specified user to validate permissions to view users.</param>
        /// <returns>A list of grades filled with values from the database.</returns>
        public List<User> Details(User model)
        {
            List<User> users = new List<User>();

            if (model.Role == "Member")
            {
                users = null;
            }
            else
            {
                using (var db = new DataConnection())
                {
                    List<User> query = (from user in db.User
                                        where user.Role != "Admin" && user.Id != model.Id
                                        select user).ToList();

                    if (query != null)
                    {
                        foreach (User _user in query)
                        {
                            user = new User()
                            {
                                Id = _user.Id,
                                Username = _user.Username,
                                Password = _user.Password,
                                Role = _user.Role
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        /// <summary>
        /// Sign an existing account in.
        /// </summary>
        /// <param name="model">User details to validate login.</param>
        /// <returns>Null on failure, user object on success.</returns>
        public User Login(User model)
        {
            User result = null;

            using (var db = new DataConnection())
            {
                User query = (from user in db.User
                              where user.Username == model.Username && user.Password == EncryptionProvider.Encrypt(model.Password)
                              select user).SingleOrDefault();

                if (query != null)
                {
                    model.Id = query.Id;
                    result = new User()
                    {
                        Id = query.Id,
                        Username = query.Username,
                        Password = query.Password,
                        Role = query.Role
                    };
                }
            }

            return result;
        }

        /// <summary>
        /// Register an unique account.
        /// </summary>
        /// <param name="model">User details to register.</param>
        /// <returns>0 on failure, 1 on success, 2 on username is invalid. 3 on Username already exist</returns>
        public int Register(User model)
        {
            int result = 0;
            bool isUsername;
            isUsername = Regex.IsMatch(model.Username, @"^(?=.{3,20}$)(?![_-])[a-zA-Z0-9-_]+(?<![_-])$", RegexOptions.None);

            if (isUsername == true)
            {
                using (var db = new DataConnection())
                {
                    User query = (from user in db.User
                                  where user.Username == model.Username
                                  select user).SingleOrDefault();

                    if (query == null)
                    {
                        model.Password = EncryptionProvider.Encrypt(model.Password);
                        result = db.Insert(model);
                    }
                    else
                    {
                        result = 3;
                    }
                }
            }
            else
            {
                result = 2;
            }
            return result;
        }

        /// <summary>
        /// Edit existing account details.
        /// </summary>
        /// <param name="id">Id of the user to update.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Edit(User model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                db.Update(model);
            }

            return result;
        }

        /// <summary>
        /// Edit existing account details.
        /// </summary>
        /// <param name="id">Id of the user to update.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Delete(User model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Delete(model);
            }

            return result;
        }

        /// <summary>
        /// Logs a user of and redirect to specified view.
        /// </summary>
        /// <param name="view">View to redirect to.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int LogOff(Type view)
        {
            int result = 0;
            ConstructorInfo constructor = view.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });
            MethodInfo method = view.GetMethod("Show", new Type[] { } );
            method.Invoke(classObject, null);

            if (method != null)
            {
                result = 1;
            }

            return result;
        }
    }
}