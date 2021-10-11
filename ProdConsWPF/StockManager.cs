using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class StockManager
    {
        private Stock MyStock;
        private Trace MyTrace;

        public StockManager(int iStockSize)//ajouter param path
        {
            MyStock = new Stock(iStockSize);
            MyTrace = new Trace(@"C:\Users\Administrateur\Documents\GL\ProdConsGL\log.txt"); //dossier log + fichier avec nom = a la date comme sophie
            Console.WriteLine("Projet prod/conso\n");

        }

      

        public void Pop()
        {
            MyStock.Pop();
            MyTrace.WriteTxt(DateTime.Now + "  POP\n");
        }
        
        public void Push(int iNValue)
        {
            MyStock.Push(iNValue);
            MyTrace.WriteTxt(DateTime.Now + "  PUSH : " + iNValue + "\n");
        }

        public void Clear()
        {
            MyStock.Clear();
            MyTrace.WriteTxt(DateTime.Now + "  CLEAR\n");

        }
    }
}
