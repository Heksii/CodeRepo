using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexYep
{
    internal class BinaryTree
    {

        private double? _value;
        private bool _split;

        private BinaryTree? _left;
        private BinaryTree? _right;
        private BinaryTree? _parent;

        public BinaryTree()
        {
            value = null;
            split = false;

            parent = null;
            left = null;
            right = null;
        }

        public BinaryTree(BinaryTree inParent)
        {
            value = null;
            split = false;

            parent = inParent;
            left = null;
            right = null;
        }

        public double? value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool split
        {
            get { return _split; }
            set { _split = value; }
        }

        public BinaryTree? left
        {
            get { return _left; }
            set { _left = value; }
        }

        public BinaryTree? right
        {
            get { return _right; }
            set { _right = value; }
        }
        public BinaryTree? parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private void Split()
        {
            left = new BinaryTree(this);
            right = new BinaryTree(this);

            split = true;
        }

        public void Insert(double val)
        {
            if (split && value != null)
            {
                if (val < value)
                {
                    left.Insert(val);
                }
                else
                {
                    right.Insert(val);
                }
            }
            else
            {
                if (value != null)
                {
                    Split();

                    left.Insert(val);
                    right.Insert(val);
                }
                else
                {
                    value = val;
                }
            }
        }

        public List<double> Query(double minRange, double maxRange)
        {
            List<double> result = new List<double>();

            if (value != null && value <= maxRange && minRange <= value)
            {
                result.Add((double)value);
            }

            if (split)
            {
                List<double> leftQuery = left.Query(minRange, maxRange);

                foreach (double item in leftQuery)
                {
                    result.Add(item);
                }

                List<double> rightQuery = right.Query(minRange, maxRange);

                foreach (double item in rightQuery)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
