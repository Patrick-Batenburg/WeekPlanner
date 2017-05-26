using System;
using System.Threading.Tasks;

namespace SamenSterk.Controllers
{
    public abstract class ControllerBase
    {
        private Task task = null;

        /// <summary>
        /// Initializes a new instance of the ControllerBase class.
        /// </summary>
        public ControllerBase()
        {
        }

        /// <summary>
        /// Adds a delegate to be invoked just before the response will be sent.
        /// </summary>
        /// <param name="callback">The callback funtion.</param>
        public virtual void OnStarting(Func<Task> callback)
        {
            if (task.IsCanceled)
            {
            }
        }

        /// <summary>
        /// Adds a delegate to be invoked after the response has finished.
        /// </summary>
        /// <param name="callback">The callback funtion.</param>
        public virtual void OnCompleted(Func<Task> callback)
        {
            if (task.IsFaulted)
            {
            }
            else if (task.IsCompleted) { }
        }
    }
}