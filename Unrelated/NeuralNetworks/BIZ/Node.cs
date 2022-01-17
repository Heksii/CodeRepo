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



        private static double Sigmoid(double value)
        {
            double k = Math.Exp(value);
            return k / (1.0f + k);
        }
    }
}
