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

        public CustomEvent OnMaxLimit;
        public CustomEvent OnminLimit;


        private Stack<int> myStack;
        private int iMaxAlert;
        private int iMinAlert;
        public Stock(int _size,int _min, int _max)
        {
            myStack = new Stack<int>(_size);
            iMaxAlert = _max;
            iMinAlert = _min;
        }

        public void Push(int iProduct)
        {
            myStack.Push(iProduct);
            if (myStack.Count >= iMaxAlert)
                OnMaxLimit(myStack.Count);
        }

        public int Pop()
        {
            int iRes = myStack.Pop();
            if (myStack.Count <= iMinAlert)
                OnminLimit(myStack.Count);
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
    }
}
