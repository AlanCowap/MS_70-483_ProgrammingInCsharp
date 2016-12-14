using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Create a generic class that holds a List of items
 * But what is the type of these items? Well, we don't know so we'll call it T
 * 
 */
namespace MS_70_483_02_CreateAndUseTypes
{
    class Catalogue<T> where T : class
    {

        private List<T> catalogue;

        public int Size { get { return catalogue.Count; } private set { } }

        public Catalogue()
        {
            this.catalogue = new List<T>();
        }

        // What datatype is T? I don't know nor do I need to know, all I need to do is add one to the Catalogue
        // Generic type can be used in the parameter list
        public void Add(T item)
        {
            this.catalogue.Add(item);
        }

        // Generic type can be used as the return type
        public T GetItemAt(int index)
        {
            if (index >= 0 && index <= this.catalogue.Count)
                return this.catalogue.ElementAt(index);
            else return null;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= this.catalogue.Count)
                this.catalogue.RemoveAt(index);
        }

        //At this point it looks like I'm just rewriting the List class as my own Catalogue class
        //But I can add whatever methods I want, or have this generic class implement an interface etc. to get additional known behaviour

        public void Pop() //Removes the last item from the Catalogue (sounds like a Stack)
        {
            int count = this.catalogue.Count;
            if (count > 0)
                this.catalogue.RemoveAt(count-1); //-1 because we index from 0, not 1.

        }

    }
}
