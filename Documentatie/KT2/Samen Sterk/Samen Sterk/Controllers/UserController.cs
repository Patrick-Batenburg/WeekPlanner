using MySql.Data.MySqlClient;
using SamenSterk.Database;
using SamenSterk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamenSterk.Providers;
using LinqToDB;
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
        /// Sign an existing account in.
        /// </summary>
        /// <param name="model">User details to validate login.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Login(User model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                User query = (from user in db.User
                              where user.Username == model.Username && user.Password == EncryptionProvider.Encrypt(model.Password)
                              select user).SingleOrDefault();

                if (query != null)
                {
                    model.Id = query.Id;
                    result = 1;
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
        /// <param name="id">Id of the user.</param>
        /// <param name="view">View to redirect to.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int LogOff(uint id, Form view)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                User query = (from user in db.User
                             where user.Id == id
                             select user).SingleOrDefault();

                if (query != null)
                {
                    result = 1;
                    view = new Form();
                    view.Show();
                }
            }

            return result;
        }
    }
}
