using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class NeuralNetwork
    {
        private List<NodeLayer> layers;
        private double fitness = 0;

        private NodeLayer input;
        private NodeLayer output;

        public NeuralNetwork(int[] layerSizes)
        {
            int index = 0;

            foreach(int layerSize in layerSizes)
            {
                NodeLayer newLayer;

                if (index > 0)
                {
                    newLayer = new NodeLayer(layerSize, Layers[index - 1]);
                }
                else
                {
                    newLayer = new NodeLayer(layerSize);
                }

                index++;
                layers.Add(newLayer);
            }

            input = layers[0];
            output = layers[layers.Count];
        }
        public NeuralNetwork(NeuralNetwork inNetwork)
        {
            Layers = inNetwork.Layers;
            Fitness = inNetwork.Fitness;

            Input = inNetwork.Input;
            Output = inNetwork.Output;
        }

        public List<NodeLayer> Layers
        {
            get { return layers; }
            set { layers = value; }
        }
        public NodeLayer Input
        {
            get { return input; }
            set { input = value; }
        }
        public NodeLayer Output
        {
            get { return output; }
            set { output = value; }
        }
        public double Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }
        
        public void Mutate()
        {
            foreach(NodeLayer layer in Layers)
            {
                layer.Mutate();
            }
        }
        public double[] PredictFromInput(double[] dataIn)
        {
            double[] res = dataIn;

            return res;
        }
    }
}
