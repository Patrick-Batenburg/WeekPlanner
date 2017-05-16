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

namespace SamenSterk.Controllers
{
    public class UserController : ControllerBase
    {
        private User user = null;
        private List<User> users = new List<User>();

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
                var query = (from user in db.User
                             where user.Username == model.Username && user.Password == model.Password/*EncryptionProvider.Encrypt(model.Password)*/
                             select user).SingleOrDefault();

                if (query != null)
                {
                    result = 1;
                }
            }

            return result;
        }


        /// <summary>
        /// Register an unique account.
        /// </summary>
        /// <param name="model">User details to register.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Register(User model)
        {
            int result = 0;
            bool isUsername;
            using (var db = new DataConnection())
            {
                var query = (from user in db.User
                             where user.Username != model.Username
                             select user).SingleOrDefault();

                if (query != null)
                {
                    isUsername = Regex.IsMatch(model.Username, @"^(?=.{3,20}$)(?![_-])[a-zA-Z0-9-_]+(?<![_-])$", RegexOptions.None);

                    if (isUsername == true)
                    {
                        model.Password = EncryptionProvider.Encrypt(model.Password);
                        result = db.Insert(model);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Edit existing account details.
        /// </summary>
        /// <param name="id">Id of the user to update.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Edit(uint id)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                var query = db.User.Where(user => user.Id == id).Delete();
                
                if (query != null)
                {
                    result = 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int LogOff(uint id)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                var query = (from user in db.User
                             where user.Id == id
                             select user).SingleOrDefault();

                if (query != null)
                {
                    result = 1;
                }
            }

            return result;
        }
    }
}
