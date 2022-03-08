using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Repository
{
    /// <summary>
    /// Class that represents a box with a width, height, depth and thickness.
    /// It contains properties that calculate volume, weight and bouyancy in water.
    /// </summary>
    public class Box : ClassNotify
    {
        private double _width;
        private double _height;
        private double _depth;
        private double _thickness;
        private double _outerVolume;
        private double _innerVolume;
        private double _weight;
        private double _bouyancy;

        private string _widthStr;
        private string _heightStr;
        private string _depthStr;

        private Material _material;

        private MediaPlayer bruhSound;

        

        public Box()
        {
            material = new Material();

            _width = 0D;
            _height = 0D;
            _depth = 0D;

            _widthStr = "0";
            _heightStr = "0";
            _depthStr = "0";

            _thickness = 0D;
            _outerVolume = 0D;
            _innerVolume = 0D;
            _weight = 0D;
            _bouyancy = 0D;

            //material = new Material("Træ", 0.987);

            bruhSound = new MediaPlayer();
        }
        
        public double width
        {
            get { return _width; }
            set 
            {
                if (double.TryParse(value.ToString(), out double x))
                {
                    _width = x;
                    UpdateProperties();
                }
            }
        }
        public double height
        {
            get { return _height; }
            set 
            {
                if (double.TryParse(value.ToString(), out double x))
                {
                    _height = x;
                    UpdateProperties();
                }
            }
        }
        public double depth
        {
            get { return _depth; }
            set 
            {
                if (double.TryParse(value.ToString(), out double x))
                {
                    _depth = x;
                    UpdateProperties();
                }
            }
        }
        public double thickness
        {
            get { return _thickness; }
            set 
            {
                if (double.TryParse(value.ToString(), out double x))
                {
                    _thickness = x;
                    UpdateProperties();
                }
            }
        }
        public double outerVolume
        {
            get { return Convert.ToDouble(Math.Truncate(_outerVolume * 1000) / 1000); }
            set
            {
                _outerVolume = value;
                Notify("outerVolume");
            }
        }
        public double innerVolume
        {
            get { return Convert.ToDouble(Math.Truncate(_innerVolume * 1000) / 1000); }
            set 
            { 
                _innerVolume = value;
                Notify("innerVolume");
            }
        }
        public double weight
        {
            get { return Convert.ToDouble(Math.Truncate(_weight * 1000) / 1000); }
            set 
            {
                _weight = value;
                Notify("weight");
            }
        }
        public double bouyancy
        {
            get { return Convert.ToDouble(Math.Truncate(_bouyancy * 1000) / 1000); }
            set 
            {
                _bouyancy = value;
                Notify("bouyancy");
            }
        }
        public Material material
        {
            get { return _material; }
            set 
            { 
                _material = value;
                UpdateProperties();
            }
        }

        public string widthStr
        {
            get { return _widthStr; }
            set 
            { 
                _widthStr = value; 
                
                if (double.TryParse(value, out double x))
                {
                    width = x;
                }
            }
        }

        public string heightStr
        {
            get { return _heightStr; }
            set
            { 
                _heightStr = value;

                if (double.TryParse(value, out double x))
                {
                    height = x;
                }
            }
        }

        public string depthStr
        {
            get { return _depthStr; }
            set 
            { 
                _depthStr = value;

                if (double.TryParse(value, out double x))
                {
                    depth = x;
                }
            }
        }

        public void UpdateProperties()
        {
            if (width > 0 && height > 0 && depth > 0 && thickness > 0)
            {
                double widthMeter = width / 100D;
                double heightMeter = height / 100D;
                double depthMeter = depth / 100D;
                double thicknessMeter = (thickness / 1000D) * 2D;
                double waterWeightPerCubicMeter = 1000D;

                outerVolume = widthMeter * heightMeter * depthMeter;
                innerVolume = (widthMeter - thicknessMeter) * (heightMeter - thicknessMeter) * (depthMeter - thicknessMeter);

                double outerVolumeWeight = outerVolume * material.weight * 1000D;
                double innerVolumeWeight = innerVolume * material.weight * 1000D;

                weight = outerVolumeWeight - innerVolumeWeight;

                bouyancy = (outerVolume * waterWeightPerCubicMeter) - weight; 
            }
            else
            {
                weight = 0D;
                bouyancy = 0D;

                outerVolume = 0D;
                innerVolume = 0D;
            }

            //bruhSound.Open(new Uri(@"C:\KodeMappe\S2\WPF\Flydekasse 2022 .Net Framework\Sounds\bruh.mp3"));
            //bruhSound.Play();
        }
    }
}
