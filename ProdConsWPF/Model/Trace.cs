using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Trace
    {
        /// faire truc virtual 
        /// 


        string sPath; 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_path">Must be a folder path (not file path)</param>
        public Trace(string _path)
        {
            string time = DateTime.Now.ToString();
            time = time.Replace(' ', '_');
            time = time.Replace('/', '_');
            time = time.Replace(':', '_');

            sPath = _path+"/Log"+ time + ".txt"; //create log file with name containing the runtime of this instance.
        }
        /// <summary>
        /// Write trace
        /// </summary>
        /// <param name="_txt">trace to write</param>
        public void WriteTxt(string _txt)
        {
            File.AppendAllText(sPath, _txt);
        }

    }
}
