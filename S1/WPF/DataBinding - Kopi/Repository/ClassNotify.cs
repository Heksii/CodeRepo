using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Repository
{
    /// <summary>
    /// Class for notifying the rest of program when properties change.
    /// </summary>
    public class ClassNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fires an event that lets the rest of the program know when any property changes.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
