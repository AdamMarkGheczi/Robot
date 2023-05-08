using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Planet Earth = new Planet("Earth");
            Planet Mars = new Planet("Mars");

            for (int i = 0; i < 5; i++)
            {
                Earth.Creatures.Add(new OrganicBeing(OrganicBeing.Species.Human));
                Earth.Creatures.Add(new OrganicBeing(OrganicBeing.Species.Animal));
            }

            for (int i = 0; i < 10; i++)
            {
                Mars.Creatures.Add(new OrganicBeing(OrganicBeing.Species.Martian));
            }

            Robot r1 = new Robot();
            r1.Initialise(Earth);

            Robot r2 = new Robot();
            r2.Initialise(Mars);


            while(Earth.ContainsLife && r1.EyeLaserIntensity != Robot.Intensity.Broken && r1.active)
            {
                r1.AcquireNextTarget();
                r1.FireLaserAt(r1.currentTarget);
            }

            while(Mars.ContainsLife && r2.EyeLaserIntensity != Robot.Intensity.Broken && r2.active)
            {
                r2.AcquireNextTarget();
                r2.FireLaserAt(r2.currentTarget);
            }

        }
    }
}