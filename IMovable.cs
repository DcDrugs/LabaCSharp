using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{
    interface IMovable
    {
        static public int MINSPEED { get; } = 0;
        int Move();
    }
}
