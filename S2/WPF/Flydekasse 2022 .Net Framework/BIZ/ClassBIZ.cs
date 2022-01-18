using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private List<Material> _materials;
        private Box _box;

        public ClassBIZ()
        {
            materials = new List<Material>();
            box = new Box();
            SetUpMaterials();
        }

        public List<Material> materials
        {
            get { return _materials; }
            set 
            { 
                _materials = value;
                Notify("materials");
            }
        }

        public Box box
        {
            get { return _box; }
            set 
            { 
                _box = value;
                Notify("box");
            }
        }

        private void SetUpMaterials()
        {
            materials.Add(new Material("Træ", 0.987));
            materials.Add(new Material("Plast", 3.378));
            materials.Add(new Material("Glas", 14.251));
            materials.Add(new Material("Jern", 25.477));
        }
    }
}
