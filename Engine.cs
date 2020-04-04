using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{
    static class Constants
    {
        public const int MAX = 26;
        public const int MAXENGINE = 100000000;
        public const int MINENGINE = 9999999;
 //       static int ID;
    }
    class Engine
    {
        private bool engine;
        public string NameEngine{ get; }
        public int EngineID{ get; }

        public Engine()
        {
            engine = false;
            Random rand = new Random();
            int[] array = new int [10];
            StringBuilder temp = new StringBuilder("        ", 9);
            string tempAlf = "qwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 10; i++)
            {
                array[i] = rand.Next() % Constants.MAX;
            }

            int j = 0;
            for (int i = 0; EngineID < Constants.MINENGINE; i += array[i % 10] % 10, j++)
            {
                array[i % 10] += i * 10 ^ j % Constants.MAX;
                EngineID = array[i % 10] * 10 ^ j;

            }
            if (EngineID > Constants.MAXENGINE)
            {
                EngineID %= Constants.MAXENGINE;
            }



            j = 0;
            while (temp[7] == ' ')
            {
                for (int i = 0; i < Constants.MAX && j < 8; i += array[i % 10] % Constants.MAX, j++)
                {
                    array[i % 10] += i;
                    temp[j] = tempAlf[i % 26];
                }
            }
            NameEngine = temp.ToString();

        }

        public bool GetStatusEngine()
        {
            return engine;
        }

        public void StopEngine()
        {
            engine = false;
        }


        public void StartEngine()
        {
            engine = true;
        }
    }
}
