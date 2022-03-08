using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassArt : ClassNotify
    {
        private int _artID;
        private string _picturePath;
        private string _pictureDescription;
        private string _pictureTitle;
        private bool _isActive;

        public ClassArt()
        {
            artID = 0;
            picturePath = "";
            pictureDescription = "";
            pictureTitle = "";
            isActive = true;
        }

        public bool isActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                }
                Notify("isActive");
            }
        }
        public int artID
        {
            get { return _artID; }
            set
            {
                if (_artID != value)
                {
                    _artID = value;
                }
                Notify("artID");
            }
        }
        public string picturePath
        {
            get { return _picturePath; }
            set
            {
                if (_picturePath != value)
                {
                    _picturePath = value;
                }
                Notify("picturePath");
            }
        }
        public string pictureDescription
        {
            get { return _pictureDescription; }
            set
            {
                if (_pictureDescription != value)
                {
                    _pictureDescription = value;
                }
                Notify("pictureDescription");
            }
        }
        public string pictureTitle
        {
            get { return _pictureTitle; }
            set
            {
                if (_pictureTitle != value)
                {
                    _pictureTitle = value;
                }
                Notify("pictureTitle");
            }
        }
    }
}
