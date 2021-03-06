﻿/**
 * MS 70-483 Programming in C#
 * Objective 2: Create and Use Types
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MS 70-483 #2 Create And Use Types");
            //new Obj21_CreateTypes().RunObjective();  //p89
            //new Obj22_ConsumeTypes().RunObjective();  //p107
            new Obj23_EnforceEncapsulation().RunObjective(); //p116

            //       // TODO 
            //        title = "\nObjective 2.4. Create and implement a class hierarchy";
            //        title = "\nObjective 2.5. Find, execute, and create types at runtime by using reflection";
            //        title = "\nObjective 2.6. Manage the object lifecycle";
            //        title = "\nObjective 2.7. Manipulate strings";
        }

    }


} //namespace
