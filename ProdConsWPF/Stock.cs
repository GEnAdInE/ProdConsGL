using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Stock
    {
        public delegate void CustomEvent(int iValue);

        private Stack<int> myStack;

        public Stock(int _size)
        {
            myStack = new Stack<int>(_size);
        }

        public void Push(int iProduct)
        {
            //try catch si plein
            myStack.Push(iProduct);
           
        }

        public int Pop()
        {
            //try catch si vide
            int iRes = myStack.Pop();
            return iRes;
        }

        public void Clear()
        {
            myStack.Clear();
        }

        public int GetCurrent()
        {
           return myStack.Peek();
        }

        public List<int> GetAllStock()
        {
            return myStack.ToList<int>();
        }

        public int GetCount()
        {
            return myStack.Count;
        }
    }
}
