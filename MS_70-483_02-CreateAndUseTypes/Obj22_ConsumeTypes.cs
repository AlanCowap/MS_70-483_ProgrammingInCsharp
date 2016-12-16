using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Obj22_ConsumeTypes
    {
        public void RunObjective()
        {
            String title = "\nObjective 2.2. Consume Types";
            Console.WriteLine(title);

            Obj22_ConsumeTypes demo = new Obj22_ConsumeTypes();
            demo.Obj22_BoxUnbox(title + ": Boxing and Unboxing"); // p107
            //demo.Obj22_TypeConversion(title + ": Type COnversion"); //p108
            //demo.Obj22_DynamicTypes(title + ": Dynamic Types"); //p112
        }

        private void Obj22_BoxUnbox(String title)
        {
            Console.WriteLine(title);

        }



    }
    }
