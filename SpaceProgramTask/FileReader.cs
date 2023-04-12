using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class FileReader
    {
        public FileReader() { }

        public List<string> GetData(string path) {
            List<string> data = new List<string>();
            try
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        data.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading from file!");
            }
                
            return data;
        }
    }
}
