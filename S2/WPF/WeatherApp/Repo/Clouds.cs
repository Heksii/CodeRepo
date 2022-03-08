using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Clouds : ClassNotify
    {
        private double _all;

        public Clouds()
        {
            all = 0D;
        }

        public double all
        {
            get { return _all; }
            set
            {
                if (_all != value)
                {
                    _all = value;
                }
                Notify("all");
            }
        }

    }
}
