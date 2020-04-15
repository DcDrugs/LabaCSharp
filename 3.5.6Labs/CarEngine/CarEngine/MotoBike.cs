using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{
    class MotoBike : Bike, IRunEngine
    {
        public Engine engine;
        private bool carIsOpen;

        public MotoBike(string bColor,int numberOfWheels) : base (bColor, numberOfWheels)
        {
            engine = new Engine();
            MAXSPEED = 300;
            carIsOpen = false;
        }

        public void StartEngine(int idItem)
        {
            if (idItem == engine.EngineID)
            {
                engine.StartEngine();
            }
            else
            {
                Console.WriteLine("Error. Undefind key");
            }
        }

        public void StopEngine(int idItem)
        {
            if (idItem == engine.EngineID && carIsOpen)
            {
                engine.StopEngine();
            }
            else
            {
                Console.WriteLine("Error. Undefind key");
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Biiiiii!!!");
        }
    }
}
