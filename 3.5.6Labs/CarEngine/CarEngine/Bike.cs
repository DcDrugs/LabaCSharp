using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{
    class Bike : Vehicle
    {
        static protected int MAXSPEED = 70;
        static protected string nameOfMiving = "drive";

        public string BColor { get; }
        public override int Move()
        {

            Console.WriteLine("Drive");
            Random rand = new Random();
            return rand.Next() % MAXSPEED;
        }

        public Bike(string bColor, int numberOfWheels) : base (nameOfMiving, numberOfWheels)
        {
            if (numberOfWheels > WHEELSBIKE)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Run from road!!!");
        }
    }
}
