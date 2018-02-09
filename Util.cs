using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Customer_Info_Filter
{
    public class Util
    {
        public static Dictionary<string, string> EmailToBuyer = new Dictionary<string, string>();
        /// <summary>
        /// Get Customer names and emails from files in folder "input". 
        /// </summary>
        public static void readFiles()
        {
            var folderPath = "input";
            var filesPath = Directory.GetFiles(folderPath);
            foreach (var path in filesPath)
            {
                var linesInFile = File.ReadAllLines(path);
                for (int i = 1; i < linesInFile.Length; i++)
                {
                    var items = linesInFile[i].Split('\t');
                    if (EmailToBuyer.ContainsKey(items[10])) continue;
                    EmailToBuyer.Add(items[10], items[11]);
                }
            }
        }
        /// <summary>
        /// Generate the email recipient string that contains all customers. 
        /// Located in folder "output". 
        /// </summary>
        public static void GenerateStr()
        {
            string temp = "";
            foreach (var key in EmailToBuyer.Keys)
                temp += key + ";";
            File.WriteAllText(@"output\GenerateStr" + DateTime.Now.ToBinary() + ".txt", temp);
            Console.WriteLine("Email string done!");
        }
        /// <summary>
        /// Create customer contacts with names and emails. 
        /// Located in folder "output". 
        /// </summary>
        public static void GenerateContact()
        {
            string temp = "";
            foreach (var eb in EmailToBuyer)
                temp += eb.Value + "\t" + eb.Key + Environment.NewLine;
            File.WriteAllText(@"output\Contact" + DateTime.Now.ToBinary() + ".txt", temp);
            Console.WriteLine("Contact created!");
        }
    }
}
