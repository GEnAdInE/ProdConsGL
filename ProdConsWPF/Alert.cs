using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
 
    
    public class Alert
    {
        enum AlertType : int
        {
            None = 0,
            BasicWithLimit = 1,
            TimeConsumtionLimit = 2,
            TimeProductionLimit = 3,
            Extern = 4,
        };
        AlertType iAlertType = AlertType.None;
    }
}
