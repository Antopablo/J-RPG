using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class TextFile
    {
        private string _path;
        private string _file;

        public TextFile(string path, string file)
        {
            _path = @"" + path;
            _file = file;
        }

        private string GetFullPath()
        {
            return _path + @"\" + _file;
        }

        public List<string> ReadFile()
        {
            List<string> content = new List<string>();
            StreamReader streamReader = new StreamReader(GetFullPath());
            while (!streamReader.EndOfStream)
            {
                // Attention la suite est potentiellement source d'erreurs
                content.Add(streamReader.ReadLine());
            }
            return content;
        }

        public void WriteFile(List<string> content)
        {
            StreamWriter streamWriter = new StreamWriter(GetFullPath(), false);
            foreach (string line in content)
            {
                streamWriter.WriteLine(line);
            }
            streamWriter.Close();
        }
    }
}
