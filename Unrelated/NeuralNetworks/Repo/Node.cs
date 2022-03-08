using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Node
    {
        private Random rnd = new Random();
        private double prediction;
        private double bias;

        public Node()
        {
            Bias = rnd.NextDouble() * 6D - 3D;
            Prediction = 0;
        }
 
        public double Prediction
        {
            get { return prediction; }
            set { prediction = value; }
        }
        public double Bias
        {
            get { return bias; }
            set { bias = value; }
        }
    }
}
