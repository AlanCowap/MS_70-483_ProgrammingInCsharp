﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Vehicle
    {
        public virtual void StartEngine() // virtual => can be overridden in derived classes
        {
            Console.WriteLine("Vehicle starting engine...");
        }

        public void StopEngine() // if it's not virtual then it's not overridden (more later)
        {
            Console.WriteLine("Vehicle stopping engine...");
        }

    }
}
