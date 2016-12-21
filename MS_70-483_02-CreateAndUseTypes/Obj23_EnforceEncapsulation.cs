/**
 * MS 70-483 Programming in C#
 * 
 *
 * @author Alan Cowap, and code from MOAC by Wouter de Kort
 * @version 1.0  
 * @dependencies None
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Obj23_EnforceEncapsulation
    {
        public void RunObjective()
        {
            String title = "\nObjective 2.3. Enforce Encapsulation";
            Console.WriteLine(title);

            Obj23_EnforceEncapsulation demo = new Obj23_EnforceEncapsulation();
            demo.Obj23_UsingAccessModifiers(title + ": Using Access Modifiers");   //p116
            //demo.Obj23_Properties(title + ": Properties"); //p120
            //demo.Obj23_ExplicitInterfaceImplementations(title + ": Explicit Interface Implementations");     //p121
        }

        private void Obj23_UsingAccessModifiers(String title)
        {
            Console.WriteLine(title);


            Console.WriteLine("\n");
        }


        private void Obj23_Properties(String title)
        {
            Console.WriteLine(title);


            Console.WriteLine("\n");
        }


        private void Obj23_ExplicitInterfaceImplementations(String title)
        {
            Console.WriteLine(title);


            Console.WriteLine("\n");
        }


    }
}
