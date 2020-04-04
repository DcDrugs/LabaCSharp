using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{
    public enum Color
    {
        Red,
        Green,
        Blue,
    }

    abstract class Car : Vehicle, IRunEngine

    {
        private bool headlight;
        private bool carIsOpen;
        static protected string nameOfMiving = "drive";
        static private int MAXSPEED = 450;
        public Engine engine;
        public string CarSolon { get; }
        public override int Move()
        {
            if (engine.GetStatusEngine())
            {
                Console.WriteLine("Drive");
                Random rand = new Random();
                return rand.Next() % MAXSPEED;
            }
            return 0;
        }
        private static class Constants
        {
            public const int MAX = 26;
            public const int MAXENGINE = 100000000;
            public const int MINENGINE = 9999999;
            //       static int ID;
        }

        public void Close(bool pressButton, int idItem)
        {
            if (pressButton && idItem == engine.EngineID)
            {
                MakeSound();
                BlinkHeadlights(1);
                carIsOpen = false;
            }
        }
        public void Open(bool pressButton, int idItem)
        {
            if (pressButton && idItem == engine.EngineID)
            {
                MakeSound();
                BlinkHeadlights(2);
                carIsOpen = true;
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bi-Bi");
        }

        public void MakeSound(int times)  
        {
            if (times > 0)
            {
                for (int i = 0; i < times; i++)
                {
                    MakeSound();
                }
            }
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
                Console.WriteLine("Error. Undefind key or Car is close");
            }
        }

        public void ChangeDippedHeadlight()
        {
            if (headlight)
            {
                headlight = false;
            }
            else
            {
                headlight = true;
            }
        }

        public bool GetDippedHeadlightStatus()
        {
            return headlight;
        }
       
        protected Car(int numberOfWheels, string carSolon, Color color) : base (nameOfMiving, numberOfWheels)
        {
            if (numberOfWheels > MAXWHEELS || numberOfWheels < MINWHEELS)
            {
                throw new IndexOutOfRangeException();
            }
            CarSolon = carSolon;
            switch (color)
            {
                case Color.Blue:
                    this.color = "Blue";
                    break;

                case Color.Green:
                    this.color = "Green";
                    break;

                case Color.Red:
                    this.color = "Red";
                    break;

            }
            headlight = false;
            carIsOpen = false;
            this.engine = new Engine();
        }

        public void ChangeColor (string color)
        {
            this.color = color;
        }
        public string GetColor()
        {
            return color;
        }
    }
}
