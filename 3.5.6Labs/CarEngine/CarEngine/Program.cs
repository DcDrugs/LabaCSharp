using System;

namespace CarEngine
{

    class Program
    {
        static int Action(IMovable movable)
        {
           return movable.Move();
        }


        static void Main(string[] args)
        {
            CarMake doje = new CarMake(6, "Штаповые", "ВАЗ-2101", "АвтоВаз", "Универсал", Color.Red);
            doje.BlinkHeadlights(2);
            Console.WriteLine("Engine status: " + doje.engine.GetStatusEngine());
            Console.WriteLine("Name of car: " + doje.Model);
            Console.WriteLine("Disk Shape Status: " + doje.DiskShape);
            Console.WriteLine("Name of engine: " + doje.engine.NameEngine);
            Console.WriteLine("Engine info: " + doje.engine.EngineID);
            doje.BlinkHeadlights(3);
            Console.WriteLine("Car color: " + doje.GetColor());
            doje.ChangeColor("Green");
            Console.WriteLine("Car color: " + doje.GetColor());
            Console.WriteLine("Dipped headlight Status: " + doje.GetDippedHeadlightStatus());
            doje.ChangeDippedHeadlight();
            Console.WriteLine("Dipped headlight Status: " + doje.GetDippedHeadlightStatus());
            doje.DiskShape = "Литые";
            Console.WriteLine("Disk Shape Status: " + doje.DiskShape);
            Console.WriteLine("Solon: " + doje.CarSolon);
            Console.WriteLine("Disk Shape Status: " + doje.Publisher);
            doje.MakeSound();
            doje.StartEngine(doje.engine.EngineID);
            doje.Open(true, doje.engine.EngineID);
            doje.StartEngine(doje.engine.EngineID);
            doje.StopEngine(doje.engine.EngineID);
            doje.Close(true, doje.engine.EngineID);
            doje.MakeSound(5);
            Console.WriteLine();
            doje.StartEngine(doje.engine.EngineID);
            Console.WriteLine("Speed status: " + Action(doje));

        }
    }
}
