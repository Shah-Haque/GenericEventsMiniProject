using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace WrapupDemo
{
    public class DataAccess<T> where T : new()
    {

        public event EventHandler<T> BadEntryFound;
        public void SaveToCSV(List<T> items, string FilePath)
        {
            List<string> rows = new List<string>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();
            string row = "";

            foreach (var col in cols)
            {
                row += $",{col.Name}";

            }

            row = row.Substring(1);
            rows.Add(row);

            foreach (var item in items)
            {
                row = "";
                bool badWordDetected = false;

                foreach (var col in cols)
                {
                    string val = col.GetValue(item, null).ToString();
                    badWordDetected = BadWordDetector(val);

                    if (badWordDetected == true)
                    {
                        BadEntryFound?.Invoke(this, item);
                        break;
                    }
                    row += $",{val}";

                }

                if (badWordDetected == false)
                {
                    row = row.Substring(1);
                    rows.Add(row);
                }


            }

            File.WriteAllLines(FilePath, rows);
        }

        private bool BadWordDetector(string stringtotest)
        {
            bool output = false;
            string LowerCaseTest = stringtotest.ToLower();

            if (LowerCaseTest.Contains("darn")
                || LowerCaseTest.Contains("frick"))
            {
                output = true;
            }
            return output;
        }
    }
}
