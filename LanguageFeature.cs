using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class LanguageFeature
    {
        public static void DisplayProcesses()
        {
            List<ProcessData> processes = new List<ProcessData>();
            foreach (var p in Process.GetProcesses())
            {
                ProcessData pd = new ProcessData();
                pd.Id = p.Id;
                pd.Name = p.ProcessName;
                pd.Memory = p.WorkingSet64;
                processes.Add(pd);
            }
            foreach (var p in processes)
                Console.WriteLine(p.ToString());
        }
    }
    class ProcessData
    {
        public Int32 Id;
        public Int64 Memory;
        public string Name;
        public override string ToString()
        {
            return String.Format("id: {0}, name: {1}, Memory: {2}", Id, Name, Memory);
        }
    }
}
