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
        
        public Stock(int _size)
        {
            myStack = new Stack<int>(_size);
            iSize = _size;
        }

        public void Push(int iProduct)
        {
            try
            {
                myStack.Push(iProduct);
            }
            catch(Exception)
            {
                OnStackFull?.Invoke();
                //eviter les erreurs en cas de listes pleine : peut etre traiter en alrme si necesaire 
            }


        }

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
                return -1;//erreur liste pleine 
            }
                
        }

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
