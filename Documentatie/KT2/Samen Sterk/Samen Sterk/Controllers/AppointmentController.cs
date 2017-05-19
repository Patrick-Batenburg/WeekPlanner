using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamenSterk.Models;
using SamenSterk.Database;
using LinqToDB;

namespace SamenSterk.Controllers
{
    public class AppointmentController
    {
        private Appointment appointment = null;

        /// <summary>
        /// Initializes a new instance of the AppointmentController class.
        /// </summary>
        public AppointmentController()
        {

        }

        /// <summary>
        /// View the details about all the appointments of the specified user.
        /// </summary>
        /// <param name="userId">User id of the appointment.</param>
        /// <returns>A list of appointments with values from the database.</returns>
        public List<Appointment> Details(uint? userId)
        {
            List<Appointment> appointments = null;

            if (userId == null)
            {
                appointments = null;
            }

            using (var db = new DataConnection())
            {
                var query = (from appointment in db.Appointment
                             where appointment.UserId == userId
                             select appointment).ToList();

                if (query != null)
                {
                    foreach (Appointment _appointment in query)
                    {
                        appointment = new Appointment()
                        {
                            Id = _appointment.Id,
                            UserId = _appointment.UserId,
                            Description = _appointment.Description,
                            Date = _appointment.Date
                        };

                        appointments.Add(appointment);
                    }
                }
            }

            return appointments;
        }

        /// <summary>
        /// Creates a new appointment.
        /// </summary>
        /// <param name="model">Appointment details to create.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Create(Appointment model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Insert(model);
            }

            return result;
        }

        /// <summary>
        /// Edit an existing appointment.
        /// </summary>
        /// <param name="model">Appointment details to edit.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Edit(Appointment model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Update(model);
            }

            return result;
        }

        /// <summary>
        /// Deletes an existing appointment.
        /// </summary>
        /// <param name="model">Appointment details to delete.</param>
        /// <returns>0 on failure, 1 on success.</returns>
        public int Delete(Appointment model)
        {
            int result = 0;

            using (var db = new DataConnection())
            {
                result = db.Delete(model);
            }

            return result;
        }
    }
}
