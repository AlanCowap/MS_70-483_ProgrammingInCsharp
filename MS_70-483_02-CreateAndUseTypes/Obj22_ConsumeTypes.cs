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
            demo.Obj22_TypeConversion(title + ": Type Conversion"); //p108
            //demo.Obj22_DynamicTypes(title + ": Dynamic Types"); //p112
        }

        private void Obj22_BoxUnbox(String title)
        {
            Console.WriteLine(title);
            //Sometimes you may want to store a value type inside a reference type
            //- could be a value type is a generic collection, or string concatenation with boolean, int etc.
            String boxing = String.Concat("Boxing helps that is ", true);
            Console.WriteLine(boxing);

            // When unboxing be sure to cast if necessary, watch for InvalidCastException at runtime.
            int answer = 42;
            Console.WriteLine("Value type is " + answer);
            Object obj = answer;
            Console.WriteLine("Boxed type is " + obj);
            int unboxAnswer = (int) obj; // that's better
            Console.WriteLine("Unboxed type is " + unboxAnswer);
            Console.WriteLine(answer + unboxAnswer + " and finally " + obj); //watch out for numeric addition vs string concatenation, just like Java ;)
            //unboxAnswer = obj; //compiler complains, obj refers to an object (not an int)
            //String oops = (String) obj; //compiler is ok, but Runtime throws an InvalidCastException

            //Be mindful of the processing overhead of un/boxing
            //Using generic collections can avoid this issue because you can store value types without boxing them

            Console.WriteLine("\n");
        }
        
        private void Obj22_TypeConversion(String title)
        {
            Console.WriteLine(title);



            Console.WriteLine("\n");
        }




        private void Obj22_DynamicTypes(String title)
        {
            Console.WriteLine(title);

            Console.WriteLine("\n");
        }



    } //class

} //namespace
