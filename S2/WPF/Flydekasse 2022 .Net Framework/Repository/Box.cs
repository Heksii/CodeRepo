using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Box : ClassNotify
    {
        private double _width;
        private double _height;
        private double _depth;
        private double _thickness;

        private Material _material;

        public Box()
        {
            
        }

        public double width
        {
            get { return _width; }
            set { _width = value; }
        }
        public double height
        {
            get { return _height; }
            set { _height = value; }
        }
        public double depth
        {
            get { return _depth; }
            set { _depth = value; }
        }
        public double thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }
        public double outerVolume
        {
            get 
            { 
                return width * height * depth; 
            }
            private set 
            {

            }
        }
        public double innerVolume
        {
            get
            {
                return (width - thickness * 2) * (height - thickness * 2) * (depth - thickness * 2);
            }
            private set
            {

            }
        }
        public double weight
        {
            get
            {
                return (outerVolume - innerVolume) * material.weight;
            }

            private set
            {

            }
        }
        public double boyancy
        {
            get
            {
                return outerVolume - innerVolume;
            }
            private set
            {

            }
        }

        public Material material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
                Notify("material");
            }
        }
    }
}
