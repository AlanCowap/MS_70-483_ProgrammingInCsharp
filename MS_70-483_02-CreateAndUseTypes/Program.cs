using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MS 70-483 #2 Create And Use Types");
            Program demo = new Program();
            String title = "\nObjective 2.1. Create Types";
            demo.Obj21_ChooseType(title + ": Choosing a type");
        }


        private void Obj21_ChooseType(String title)
        {
            Console.WriteLine(title);

        }

    }
}
