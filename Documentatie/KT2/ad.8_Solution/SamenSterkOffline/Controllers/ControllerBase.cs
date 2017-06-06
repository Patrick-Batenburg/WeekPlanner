using System;
using System.Threading.Tasks;

namespace SamenSterkOffline.Controllers
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
        public async Task OnStarting(Func<Task> callback)
        {
            task = new Task(() =>
            {

            });

            if (task.IsCanceled)
            {
                task.Dispose();
            }

            await task;
        }

        /// <summary>
        /// Adds a delegate to be invoked after the response has finished.
        /// </summary>
        /// <param name="callback">The callback funtion.</param>
        public async Task<bool> OnCompleted(Func<Task> callback)
        {
            bool result = false;
            await task;

            if (task.IsFaulted)
            {
                result = false;
            }
            else if (task.IsCompleted)
            {
                result = true;
            }

            return result;
        }
    }
}