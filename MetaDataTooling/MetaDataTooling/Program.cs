using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDataTooling
{
    class Program
    {
        private const string GUID_REGEX = @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}";
        static void Main(string[] args)
        {
            var path = Console.ReadLine();
            if (path == "")
                path = @"E:\vt_datamanagement_src";
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
                    var content = sr.ReadToEnd().Replace("\t", "")
                        .Replace("\r", "").Replace("\n", "").Replace("\"", "");
                    var projects = content.Split(new string[1] { "Project" },
                        StringSplitOptions.RemoveEmptyEntries).ToList();
                    //for (int i = 0; i < projects.Count; i++)
                    //    projects[i] = "Project_" + projects[i];
                    //projects.RemoveAll(x => !(x.StartsWith("Project_") && x.EndsWith("End")));
                    projects.RemoveAll(x => !(Regex.Matches(x,
                        GUID_REGEX).Count == 2));
                    projects.RemoveAll(x => !(x.Contains(".csproj")));
                    for (int i = 0; i < projects.Count; i++)
                    {
                        projects[i] = projects[i].Replace("\n", "").Replace("\r", "");
                        var help = projects[i].Split('=');
                        projects[i] = help[0] + "|" + help[1].Split(',').ToList()
                            .ConvertAll<string>(x => x[0] + "|" + x[1] + "|" + x[2]);
                    }
                    
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
