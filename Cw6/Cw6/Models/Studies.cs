using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Models
{
    //byt stworzony ponad potrzebę, ale przyda się pewnie później
    public class Studies
    {
        public int IdStudy { get; set; }
        public string Name { get; set; }

        public Studies(int id, string name)
        {
            IdStudy = id;
            Name = name; 
        }

        public Studies() { }

        public override string ToString()
        {
            return Name; 
        }


    }
}
