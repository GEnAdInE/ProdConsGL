using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdConsoTP1
{
    public class Cons
    {
        public delegate void POPEvent();
        public event POPEvent NewPOP;
        public Cons()
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
            process.StandardInput.WriteLine("CONS\n");

            while (!bexit)
            {
                string sCurrentEntry = process.StandardOutput.ReadLine();
                if (sCurrentEntry == "POP")
                {
                    NewPOP?.Invoke();
                }

            }
            process.WaitForExit();
        }

    }
}
