using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class OrganicBeing
    {
        public enum States
        {
            Alive,
            Stunned,
            Dead
        }

        public enum Species
        {
            Human,
            Martian,
            Animal
        }

        public static int nrHumans = 0;
        public static int nrMartians = 0;
        public static int nrAnimals = 0;

        public int id;
        public States condition { get; set; }
        public bool isAlive { get { return condition == States.Alive; } private set { } }
        public Species species { get; }
        public OrganicBeing(Species species)
        {
            condition = States.Alive;
            this.species = species;
            switch(species)
            {
                case Species.Human:
                    nrHumans++;
                    id = nrHumans;
                    break;
                case Species.Martian:
                    nrMartians++;
                    id = nrMartians;
                    break;
                case Species.Animal:
                    nrAnimals++;
                    id = nrAnimals;
                    break;
            }
        }

        public override string ToString()
        {
            return species.ToString() + $"#{id}";
        }
    }
}
