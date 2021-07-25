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
        delegate Boolean FilterDelegate(Process process);
        public static Boolean Filter(Process process)
        {
            return process.WorkingSet64 >= 80 * 1024 * 1024;
        }
        public static void DisplayWithDelegate()
        {
            DisplayProcesses(Filter);
        }
        public static void DisplayProcesses()
        {
            List<ProcessData> processes = new List<ProcessData>();
            foreach (var p in Process.GetProcesses())
            {
                ProcessData pd = new ProcessData
                {
                    Id = p.Id,
                    Name = p.ProcessName,
                    Memory = p.WorkingSet64,
                };
                processes.Add(pd);
            }
            foreach (var p in processes)
                Console.WriteLine(p.ToString());
        }
        public static void DisplayProcesses(Predicate<Process> match)
        {
            var processes = new List<ProcessData>();
            foreach(var p in Process.GetProcesses())
            {
                if (match(p))
                {
                    processes.Add(new ProcessData{
                        Id = p.Id,
                        Name = p.ProcessName,
                        Memory = p.WorkingSet64,
                    });
                }
            }
            // Display processes
            foreach(var p in processes)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
    class ProcessData
    {
        public Int32 Id { get; set; }
        public Int64 Memory { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("id: {0}, name: {1}, Memory: {2}", Id, Name, Memory);
        }
    }
}
