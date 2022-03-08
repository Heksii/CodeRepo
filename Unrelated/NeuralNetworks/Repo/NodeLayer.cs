using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class NodeLayer
    {
        private Random rnd = new Random();

        private List<Node> nodes;
        private List<NodeConnection> nodeCons;

        public NodeLayer(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Nodes.Add(new Node());
            }
        }
        public NodeLayer(int size, NodeLayer connectedTo)
        {
            for (int i = 0; i < size; i++)
            {
                Node newNode = new Node();
                Nodes.Add(new Node());

                foreach (Node node in connectedTo.nodes)
                {
                    NodeCons.Add(new NodeConnection(node, newNode));
                }
            }
        }
        public NodeLayer(NodeLayer inLayer)
        {
            Nodes = inLayer.Nodes;
            NodeCons = inLayer.NodeCons;
        }

        public List<Node> Nodes {
            get { return nodes; }
            set { nodes = value; }
        }
        public List<NodeConnection> NodeCons
        {
            get { return nodeCons; }
            set { nodeCons = value; }
        }
   
        public void Mutate()
        {
            foreach (Node node in Nodes)
            {
                node.Bias += (rnd.NextDouble() * 2 + 1) / 20;
            }

            foreach (NodeConnection nodeCon in NodeCons)
            {
                nodeCon.Weight += (rnd.NextDouble() * 2 + 1) / 20;
            }
        }
    }
}
