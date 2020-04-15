using System;
using System.Collections.Generic;
using System.Text;


namespace CarEngine
{
    abstract class Vehicle : IMovable
    {

        protected const int MAXWHEELS = 8;
        protected const int MINWHEELS = 3;
        protected const int WHEELSSHIP = 0;
        protected const int WHEELSBIKE = 4;
        protected const int WHEELSFLY = 10;
        protected string color;

        protected int NumberOfWheels { get; }
        public string MovingEnviremont {get;}

        public Vehicle (string nameOfMiving, int numberOfWheels)
        {
            NumberOfWheels = numberOfWheels;
            MovingEnviremont = nameOfMiving;

        }

        public virtual void BlinkHeadlights(int times)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vehicle make Blink " + times + " times");
            Console.ResetColor();
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Make Sound");
        }

        public virtual int Move()
        {
                Console.WriteLine("maybe it's moving");
            return 0;
        }



    }
}
