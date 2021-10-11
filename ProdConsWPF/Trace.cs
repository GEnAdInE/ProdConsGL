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
        public Trace(string _path)
        {
            sPath = _path;
        }

        public void WriteTxt(string _txt)
        {
            File.AppendAllText(sPath, _txt);
        }

        public void DelFile()
        {
            File.Delete(sPath);
        }

    }
}
