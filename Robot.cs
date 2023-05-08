using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Robot
    {
        public enum Intensity
        {
            Kill,
            Stun,
            Off,
            Broken
        }

        public static int nrOfRobots = 0;
        public bool active;
        public OrganicBeing currentTarget;
        public Planet currentPlanet;
        public Intensity EyeLaserIntensity;
        public int serialNumber;


        public Robot()
        {
            active = false;
            nrOfRobots++;
            serialNumber = nrOfRobots;
        }

        public void Initialise(Planet planet)
        {
            Console.WriteLine($"Robot#{serialNumber} deployed on planet {planet}");
            active = true;
            currentPlanet = planet;
        }

        public void MoveToPlanet(Planet planet)
        {
            currentPlanet = planet;
        }

        public void AcquireNextTarget()
        {
            foreach(OrganicBeing being in currentPlanet.Creatures)
            {
                if(being.isAlive)
                {
                    currentTarget = being;
                    break;
                }
            }
        }

        private int nrOfFirings = 0;

        public void FireLaserAt(OrganicBeing target)
        {
            if (nrOfFirings > 5) EyeLaserIntensity = Intensity.Broken;

            switch(EyeLaserIntensity)
            {
                case Intensity.Kill:
                    target.condition = OrganicBeing.States.Dead;
                    Console.WriteLine($"#{serialNumber}: Destroyed {target}");
                    nrOfFirings++;
                    break;
                case Intensity.Stun:
                    target.condition = OrganicBeing.States.Stunned;
                    nrOfFirings++;
                    break;
                case Intensity.Off:
                    Console.WriteLine($"#{serialNumber}: Unable to fire, laser inactive");
                    break;
                case Intensity.Broken:
                    Console.WriteLine($"#{serialNumber}: Unable to fire, laser malfunctioning");
                    break;
            }
        }
    }
}
