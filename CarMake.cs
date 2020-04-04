using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{
    class CarMake : Car
    {


        public CarMake(int numberOfWheels, string diskShape, string model, string publisher, string carSolon, Color color) : base (numberOfWheels, carSolon, color)
        {
            this.DiskShape = diskShape;
            this.Model = model;
            this.Publisher = publisher;
        }

        public string Model { get; }

        public string Publisher { get; }

        public string DiskShape { get; set; }

        public override void BlinkHeadlights(int times)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
            Console.WriteLine("Car make Blink " + times + " times");
            Console.ResetColor();
        }
    }
}
