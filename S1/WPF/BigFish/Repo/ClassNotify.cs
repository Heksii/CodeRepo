using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    /// <summary>
    /// En klasse der er ansvarlig for at få data binding til at virke,
    /// den fyrer et event af når man kalder metoden Notify med et argument
    /// som vil være navnet på det property du vil notify resten af programmet om.
    /// </summary>
    public class ClassNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public ClassNotify()
        {

        }

        /// <summary>
        /// En metode man kan kalde som fyrer et event som resten af programmet kan lytte efter.
        /// </summary>
        /// <param name="propertyName">string</param>
        protected void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
