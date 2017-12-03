using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataTooling
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine();
            if (path == "")
                path = @"C:\Users\torst\Desktop\vt_datamanagement_src";
            while (!Directory.Exists(path))
            {
                Console.WriteLine("Path not found. Please retry...");
                path = Console.ReadLine();
            }
            var slnList = Directory.GetFiles(path, "*.sln", SearchOption.AllDirectories);
            var csprojList = Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories);
            var slnDict = new Dictionary<string, List<string>>();
            foreach (var sln in slnList)
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path, sln), Encoding.Default))
                {
                    var content = sr.ReadToEnd();
                    var projects = content.Split(new string[1] { "Project" },
                        StringSplitOptions.RemoveEmptyEntries)[1].Split('=')[1].Split(',');
                    for (int i = 0; i < projects.Length; i++)
                        projects[i] = projects[i].Replace("\"", "").Replace("\r", "")
                            .Replace("\n", "").Replace("End", "");
                    slnDict.Add(sln, projects.ToList());
                }
            }
        }
    }

    public static class CustomExtensions
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("The string is null or emty", "value");
            List<int> indices = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indices;
                indices.Add(index);
            }
        }
    }
}
