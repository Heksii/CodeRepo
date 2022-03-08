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

        public NodeConnection(Node n1, Node n2)
        {
            Node1 = n1;
            Node2 = n2;
        }
        public NodeConnection(NodeConnection inCon)
        {
            Node1 = inCon.Node1;
            Node2 = inCon.Node2;
        }

        public Node Node1
        {
            get { return node1; }
            set { node1 = value; }
        }
        public Node Node2
        {
            get { return node2; }
            set { node2 = value; }
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
