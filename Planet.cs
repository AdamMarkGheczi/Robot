using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Planet
    {
        public List<OrganicBeing> Creatures;
        public string name;

        public bool ContainsLife
        {
            get
            { 
                foreach(OrganicBeing org in Creatures)
                {
                    if(org.isAlive) return true;
                }

                return false;
            }

        }

        public Planet(string name)
        {
            Creatures = new List<OrganicBeing>();
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
