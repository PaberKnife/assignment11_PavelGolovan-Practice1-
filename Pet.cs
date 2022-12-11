using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment11_PavelGolovan_Practice1_
{
    class Pet
    {
        private string _name;
        private string _type;
        private int _age;

        public Pet()
        {
            _name = "";
            _type = "";
            _age = -1;
        }

        public string Show()
        {
            return "Selected pet:\nName: " + Name + ";\nType: " + Type + ";\nAge: " + Age.ToString() + ".";
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}