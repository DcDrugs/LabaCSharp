using System;
using System.Collections.Generic;
using System.Text;

namespace CarEngine
{

    interface IRunEngine
    {
        public void StartEngine(int idItem);

        public void StopEngine(int idItem);
    }
}
