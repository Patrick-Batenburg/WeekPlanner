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

namespace SamenSterk.Controllers
{
    public class UserController : ControllerBase
    {
        public int Login(User model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                var query = (from user in db.User
                             where user.Username == model.Username && user.Password == EncryptionProvider.Encrypt(model.Password)
                             select user).SingleOrDefault();
                if (result != null)
                {
                    result = 1;
                }
            }

            return result;
        }

        public int Register(User model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Insert(model);
            }

            return result;
        }
    }
}
