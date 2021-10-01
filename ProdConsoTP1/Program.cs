using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Program
    {

        
        static void Main(string[] args)
        {
            Stock MyStock;
            string sMyInput = string.Empty;
            int iValueToAdd = 0;
            int iCurrentValue = 0;

            Console.WriteLine("Projet prod/conso\n");

            MyStock = new Stock(10,2,8);

            while(true)
            {
                Console.WriteLine(MyStock.GetCurrent()+"\n");

                 sMyInput = Console.ReadLine();
                
                if(sMyInput.StartsWith("PUSH"))
                {
                    int.TryParse(sMyInput.Remove(0, 5),out iValueToAdd);
                    MyStock.Push(iValueToAdd);
                }


            }


        }


       
    }
}
