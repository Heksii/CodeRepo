using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private double _resPlus;
        private double _resMinus;
        private double _resGange;
        private double _resDivi;
        private string _tal1;
        private string _tal2;

        public ClassBIZ()
        {
            tal1 = "0";
            tal2 = "0";
            tal1Dub = 0D;
            tal2Dub = 0D;
        }        

        public double tal1Dub { get; set; }
        public double tal2Dub { get; set; }

        public string tal2
        {
            get { return _tal2; }
            set
            {
                if (_tal2 != value)
                {
                    if (value == "-")
                    {
                        _tal2 = "-";
                        tal2Dub = 0;
                        StartCalck();
                    }
                    if (value.Trim() == "")
                    {
                        _tal2 = "";
                        tal2Dub = 0;
                        StartCalck();
                    }
                    if (double.TryParse(value, out double x))
                    {
                        _tal2 = value;
                        tal2Dub = x;
                        StartCalck();
                    }
                }
                Notify("tal2");
            }
        }


        public string tal1
        {
            get { return _tal1; }
            set
            {
                if (_tal1 != value)
                {
                    if (value == "-")
                    {
                        _tal1 = "-";
                        tal1Dub = 0;
                        StartCalck();
                    }
                    if (value.Trim() == "")
                    {
                        _tal1 = "";
                        tal1Dub = 0;
                        StartCalck();
                    }
                    if (double.TryParse(value, out double x))
                    {
                        _tal1 = value;
                        tal1Dub = x;
                        StartCalck();
                    }                    
                }
                Notify("tal1");
            }
        }


        public double resDivi
        {
            get { return _resDivi; }
            set
            {
                if (_resDivi != value)
                {
                    _resDivi = value;
                }
                Notify("resDivi");
            }
        }


        public double resGange
        {
            get { return _resGange; }
            set
            {
                if (_resGange != value)
                {
                    _resGange = value;
                }
                Notify("resGange");
            }
        }


        public double resMinus
        {
            get { return _resMinus; }
            set
            {
                if (_resMinus != value)
                {
                    _resMinus = value;
                }
                Notify("resMinus");
            }
        }


        public double resPlus
        {
            get { return _resPlus; }
            set
            {
                if (_resPlus != value)
                {
                    _resPlus = value;
                }
                Notify("resPlus");
            }
        }

        private void StartCalck()
        {
            resPlus = MakeResPlus();
            resMinus = MakeResMinus();
            resGange = MakeResGange();
            resDivi = MakeResDivi();
        }

        private double MakeResPlus()
        {
            return tal1Dub + tal2Dub;
        }
        private double MakeResMinus()
        {
            return tal1Dub - tal2Dub;
        }
        private double MakeResGange()
        {
            return tal1Dub * tal2Dub;
        }
        private double MakeResDivi()
        {
            double res = 0D;
            if (tal2Dub != 0D)
            {
                res = tal1Dub / tal2Dub;
            }
            return res;
        }

        public double TestOutOfRangeException(int inNo)
        {
            double[] arr = new double[] { 2, 6, 9 };

            return arr[inNo];
        }

        public double TestDivideByZeroException(double a, double b)
        {
            double res = a / b;
            if (double.IsInfinity(res)) throw new DivideByZeroException();

            return res;
        }
    }
}
