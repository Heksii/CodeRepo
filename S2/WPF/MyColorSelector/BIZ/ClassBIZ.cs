using Repository;

namespace BIZ
{
    public class ClassBIZ
    {
        private ClassBackgrundColor _colorData;
        private ClassBackgrundColor _colorData2;

        public ClassBIZ()
        {
            colorData = new ClassBackgrundColor();
            colorData2 = new ClassBackgrundColor();
        }

        public ClassBackgrundColor colorData
        {
            get { return _colorData; }
            set
            {
                if (_colorData != value)
                {
                    _colorData = value;
                }
            }
        }

        public ClassBackgrundColor colorData2
        {
            get { return _colorData2; }
            set
            {
                if (_colorData2 != value)
                {
                    _colorData2 = value;
                }
            }
        }
    }
}
