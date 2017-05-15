using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamenSterk.Controllers
{
    public abstract class ControllerBase 
    {
        public Dictionary<string, string> TempData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event fires when a property has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property or field.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
