using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Node
    {
        private double prediction;
        private double bias;

        public Node()
        {

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
