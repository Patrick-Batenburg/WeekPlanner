using LinqToDB;
using SamenSterkOnline.Database;
using SamenSterkOnline.Models;
using SamenSterkOnline.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SamenSterkOnline.Controllers
{
    public class UserController
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

			if (model != null)
			{
				if (model.Role == "Member")
				{
					users = null;
				}
				else
				{
					try
					{
						using (DataConnection db = new DataConnection())
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
					catch (Exception)
					{
						users = null;
					}
				}
			}

			return users;
        }

        /// <summary>
        /// Sign an existing account in.
        /// </summary>
        /// <param name="model">User details to validate login.</param>
        /// <returns>Null on failure, User object on success.</returns>
        public User Login(User model)
        {
            User result = null;

			try
			{
				using (DataConnection db = new DataConnection())
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
			}
			catch (Exception)
			{
                result = new User()
                {
                    Role = "Error"
                };
            }

            return result;
        }

		/// <summary>
		/// Register an unique account.
		/// </summary>
		/// <param name="model">User details to register.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Register(User model)
        {
            int result = 0;
            bool isUsername = false;

			if (model != null)
			{
				if (!string.IsNullOrEmpty(model.Username))
				{
					isUsername = Regex.IsMatch(model.Username, @"^(?=.{3,32}$)(?![_-])[a-zA-Z0-9-_ ]+(?<![_-])$", RegexOptions.None);
				}
			}

			if (isUsername == true)
            {
				try
				{
					using (DataConnection db = new DataConnection())
					{
						User query = (from user in db.User
									  where user.Username == model.Username
									  select user).SingleOrDefault();

						if (query == null)
						{
							model.Password = EncryptionProvider.Encrypt(model.Password);
							result = db.Insert(model);
						}
					}
				}
				catch (Exception)
				{
					result = 2;
                }
            }

            return result;
        }

		/// <summary>
		/// Edit existing account details.
		/// </summary>
		/// <param name="id">Id of the user to update.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Edit(User model)
        {
            int result = 0;

			try
			{
				using (DataConnection db = new DataConnection())
				{
					db.Update(model);
				}
			}
			catch (Exception)
			{
				result = 2;
			}

			return result;
        }

		/// <summary>
		/// Edit existing account details.
		/// </summary>
		/// <param name="id">Id of the user to update.</param>
		/// <returns>0 on failure, 1 on success, 2 on unexpected database error.</returns>
		public int Delete(User model)
        {
            int result = 0;

			try
			{
				using (DataConnection db = new DataConnection())
				{
					result = db.Delete(model);
				}
			}
			catch (Exception)
			{
				result = 2;
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

			if (view != (Type)null)
			{
				ConstructorInfo constructor = view.GetConstructor(Type.EmptyTypes);
				object classObject = constructor.Invoke(new object[] { });
				MethodInfo method = view.GetMethod("Show", new Type[] { });
				method.Invoke(classObject, null);

				if (method != null)
				{
					result = 1;
				}
			}

            return result;
        }
    }
}