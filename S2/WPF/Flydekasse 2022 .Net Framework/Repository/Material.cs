using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Material
    {
        private string _name;
        private double _weight;

        public Material(Material inMat)
        {
            weight = inMat.weight;
            name = inMat.name;
        }

        public Material(string newName, double newWeight)
        {
            weight = newWeight;
            name = newName;
        }

        public double weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string name
        {
            get { return $"{_name} - {weight}kg pr. dm³"; }
            set { _name = value; }
        }
    }
}
