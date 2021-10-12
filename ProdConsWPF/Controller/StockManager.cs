using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProdConsoTP1.Stock;

namespace ProdConsoTP1
{
    public class StockManager
    {
        private static Stock MyStock; //static beceause there is only one Stock to be managed
        private Trace MyTrace;
        public Alert MyAlert;

        public delegate void PopOrPushAppend(int iValue);
        public event PopOrPushAppend ValuePushed;
        public event PopOrPushAppend ValuePoped;
        public event StackIssue issue; //can be used to alert when there have been an issue

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iStockSize">Size of the stock</param>
        /// <param name="_spath">Folder path for log</param>
        public StockManager(int iStockSize,string _spath)//ajouter param path
        {
            MyStock = new Stock(iStockSize);
            MyAlert = new Alert(this);

            bool exists = System.IO.Directory.Exists(_spath);
            if(!exists)
                System.IO.Directory.CreateDirectory(_spath);
            MyTrace = new Trace(_spath); //dossier log
        }


        #region Basic Function
        public int Pop()
        {
            int iValue = MyStock.Pop();
            MyTrace.WriteTxt(DateTime.Now + "  POP\n");
            ValuePoped?.Invoke(iValue);
            return iValue;
        }
        
        public void Push(int iNValue)
        {
            MyStock.Push(iNValue);
            MyTrace.WriteTxt(DateTime.Now + "  PUSH : " + iNValue + "\n");
            ValuePushed?.Invoke(iNValue);
        }

        public void Clear()
        {
            MyStock.Clear();
            MyTrace.WriteTxt(DateTime.Now + "  CLEAR\n");

        }
        #endregion

        #region HelperFunction

        /// <summary>
        /// Get Current number of item in stack
        /// </summary>
        /// <returns></returns>
        public int GetCurrentCount()
        {
            return MyStock.GetCount();
        }

        /// <summary>
        /// Get defined stackSized
        /// </summary>
        /// <returns></returns>
        public int GetStackSize()
        {
            return MyStock.GetSize();
        }

        public List<int> ToList()
        {
            return MyStock.GetAllStock();
        }
        #endregion

    }
}
