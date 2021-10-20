using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Alert
    {
        private StockManager myStockManagerRef;

        public delegate void AlertTriggered(object obj);//you can customize this delegate to transmit more value
        public event AlertTriggered OnAlertTriggered;
        public event AlertTriggered OnAlertTriggeredEnd;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_stockManager">a ref to the stockManager</param>
        public Alert(StockManager _stockManager)
        {
            myStockManagerRef = _stockManager;
            myStockManagerRef.ValuePushed += MyStockManagerRef_ValuePushed; //sub to push
            myStockManagerRef.ValuePoped += MyStockManagerRef_ValuePoped; //sub to pop
        }

        

        #region CustomAlert1

        private int iTopAlert = 5; //exemple alert top Limit
        bool bAlertOnOff = true;
        /// <summary>
        /// Alert1
        /// </summary>
        /// <param name="iValue"></param>
        private void MyStockManagerRef_ValuePushed(int iValue)
        {
            //do your test here and then trigger an Alert
            if(bAlertOnOff && GetCurrentCount()>=iTopAlert)
            {
                
                //trigger alert
                OnAlertTriggered?.Invoke(null);
                bAlertOnOff = false;
            }
        }

        /// <summary>
        /// Event to catch poped value
        /// </summary>
        /// <param name="iValue"></param>
        private void MyStockManagerRef_ValuePoped(int iValue)
        {
            if (!bAlertOnOff && GetCurrentCount() < iTopAlert)
            {

                //trigger alert
                OnAlertTriggeredEnd?.Invoke(null);
                bAlertOnOff = true;
            }
        }
        #endregion

        #region Basic Helper Function

        /// <summary>
        /// Get the avaible stock
        /// </summary>
        /// <returns></returns>
        private int GetCurrentCount()
        {
           return myStockManagerRef.GetCurrentCount();           
        }

        /// <summary>
        /// Get remain SpaceLeft()
        /// </summary>
        /// <returns></returns>
        private int GetRemainingSpaceLeft()
        {
            int result = myStockManagerRef.GetStackSize() - GetCurrentCount();
            return result;
        }

        /// <summary>
        /// Get the number of Identical item
        /// </summary>
        /// <returns></returns>
        private int NumberOfIdenticalItem()
        {
            List<int> tmpList = myStockManagerRef.ToList();
            int total = tmpList.GroupBy(item => item).Where(item => item.Count() > 1).Sum(item => item.Count());
            return total;
        }
        #endregion
    }
}
