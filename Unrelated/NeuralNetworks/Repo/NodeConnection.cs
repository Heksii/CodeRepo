using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class NodeConnection
    {
        private Node node1;
        private Node node2;

        private double weight;

        public NodeConnection()
        {
            node1 = new Node();
            node2 = new Node();
        }

        public double Weight {
            get 
            {
                return weight;
            }
            set 
            {
                if (value != weight)
                {
                    weight = value;
                }
            }
        
        }

        public NodeConnection(Node n1, Node n2)
        {
            node1 = n1;
            node2 = n2;
        }

        private static double Sigmoid(double value)
        {
            double k = Math.Exp(value);
            return k / (1.0f + k);
        }

        public void Send()
        {
            node2.Prediction = Sigmoid(node1.Prediction + node1.Bias) * Weight;
        }
    }
}
