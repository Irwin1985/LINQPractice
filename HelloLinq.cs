using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class HelloLinq
    {        
        static void Main(string[] args)
        {
            //LinqToXML.ShowSample();
            //LinqToSQL.ShowSample();
            //ShowProcessList();
            LanguageFeature.DisplayWithDelegate();
        }
        public static void ShowProcessList()
        {
            List<String> processes = new List<string>();
            foreach (Process process in Process.GetProcesses())
            {
                processes.Add(process.ProcessName);                
            }
            foreach(var p in processes)
                Console.WriteLine(p);
        }
        public static void ConnecToSQLServer()
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=PC-IRWIN\SQLIRWIN;Initial Catalog=Northwind;User ID=sa;Password=Subifor2012";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            Console.WriteLine("Connection Ok");
            cnn.Close();
        }
        public static void HelloWorld()
        {
            string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };
            
            var shortWords =
                from word in words
                where word.Length <= 5
                select word;

            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }
        public static void HelloGroupedWorld()
        {
            string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };
            var groups =
                from word in words
                orderby word ascending
                group word by word.Length into lengthGroups
                orderby lengthGroups.Key descending
                select new { Length = lengthGroups.Key, Words = lengthGroups };

            foreach(var group in groups)
            {
                Console.WriteLine("Words of length " + group.Length);
                foreach(string word in group.Words)
                    Console.WriteLine("  " + word);
            }
        }
    }
}
