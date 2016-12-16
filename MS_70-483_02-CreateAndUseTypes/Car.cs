using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Car : Vehicle //this class extends the Vehicle  class
    {
        public override void StartEngine() // this method extends the StartEngine method in the Base class, otherwise use new keyword
        {
            Console.WriteLine("Car starting engine...");
        }
        public void StopEngine() // this is "Hiding" not "Overriding" (more later...)
        {
            Console.WriteLine("Car stopping engine...");
        }


    }
}
