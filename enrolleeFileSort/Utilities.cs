using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnrolleeFileSort
{
    public static class Utilities
    {
        public static Enrollee parseFile(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Enrollee member = new Enrollee();
            member.userId = Convert.ToString(values[0]);
            member.firstName = Convert.ToString(values[1]);
            member.lastName = Convert.ToString(values[2]);
            member.versionNumber = Convert.ToInt32(values[3]);
            member.insuranceCompany = Convert.ToString(values[4]);
            return member;
        }

        public static void ExportCsv<T>(List<T> genericList, string fileName)
        {
            var sb = new StringBuilder();
            var basePath = "C:\\Output";
            var finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();
            if (!File.Exists(finalPath))
            {
                var file = File.Create(finalPath);
                file.Close();
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + "; ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    }
}
