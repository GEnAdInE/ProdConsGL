using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Prod
    {
        public delegate void PUSHEvent(int iNValue);
        public event PUSHEvent NewPUSH;
        public Prod()
        {
            bool bexit = false;
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            var process = new Process { StartInfo = startInfo };

            process.Start();
            process.StandardInput.WriteLine("echo PROD\n");
            
            /*
            while(!bexit)
            {
                string sCurrentEntry = process.StandardOutput.ReadLine();
                if (sCurrentEntry.StartsWith("PUSH"))
                {
                    string[] sSplitTab = sCurrentEntry.Split(' ');
                    if(sSplitTab.Length > 1)
                    {
                        int iNewElement = 0;
                        if(int.TryParse(sSplitTab[1], out iNewElement))
                        {
                            NewPUSH?.Invoke(iNewElement);
                        }

                    }
                }
                
            }*/
            process.WaitForExit();

        }
    }
}
