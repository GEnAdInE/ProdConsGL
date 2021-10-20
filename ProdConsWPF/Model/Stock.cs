using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Stock
    {
        public delegate void StackIssue();
        public event StackIssue OnStackFull;
        public event StackIssue OnStackEmpty;
        private Stack<int> myStack;
        private int iSize;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_size"></param>
        public Stock(int _size)
        {
            
            myStack = new Stack<int>(_size);
            iSize = _size;
        }

        /// <summary>
        /// Push
        /// </summary>
        /// <param name="iProduct"></param>
        public void Push(int iProduct)
        {
            
            if(GetCount()<iSize)
                myStack.Push(iProduct);
            else
                OnStackFull?.Invoke();//avoid error in case of full list : can be treated as an alarm

          


        }

        /// <summary>
        /// Pop
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            try
            {
                int iRes = myStack.Pop();
                return iRes;
            }
            catch(Exception)
            {
                OnStackEmpty?.Invoke();
                return -1;//error on empty list 
            }
                
        }

        /// <summary>
        /// Clear stock
        /// </summary>
        public void Clear()
        {
            myStack.Clear();
        }

        /// <summary>
        /// Show top item without removing it
        /// </summary>
        /// <returns></returns>
        public int GetCurrent()
        {
           return myStack.Peek();
        }

        /// <summary>
        /// Return the stock as a list , can be usefullt for the next version
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllStock()
        {
            return myStack.ToList<int>();
        }

        /// <summary>
        /// Get Number of Element in stack
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return myStack.Count;
        }
        /// <summary>
        /// Get MaxSize of stack
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return iSize;
        }
    }
}
