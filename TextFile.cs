using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class TextFile : IEnumerable<string>
    {
        private string _path;
        private string _file;
        private int _count;

        public TextFile(string path, string file) : this(path, file, false) { }

        public TextFile(string path, string file, bool empty)
        {
            _path = @"" + path;
            _file = file + "-Map.txt";
            _count = -1;
            if (empty)
            {
                StreamWriter streamWriter = new StreamWriter(GetFullPath(), false);
                streamWriter.Close();
            }
        }

        private string GetFullPath()
        {
            return _path + @"\" + _file;
        }

        public int Count
        {
            get
            {
                if (_count < 0)
                {
                    _count = 0;
                    foreach (string line in this)
                    {
                        _count++;
                    }
                }
                return _count;
            }
        }

        public string this[int index]
        {
            get
            {
                string line = null;
                StreamReader streamReader = new StreamReader(GetFullPath());
                try
                {
                    for (int i = 0; i < index; i++)
                    {
                        streamReader.ReadLine();
                    }
                    line = streamReader.ReadLine();
                }
                catch (IOException)
                {
                    throw new IndexOutOfRangeException();
                }
                finally
                {
                    streamReader.Close();
                }
                return line;
            }

            set
            {
                string content = "";
                StreamReader streamReader = new StreamReader(GetFullPath());
                try
                {
                    for (int i = 0; i < index; i++)
                    {
                        content += streamReader.ReadLine() + "\r\n";
                    }
                    content += value;
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        content += "\r\n" + streamReader.ReadLine();
                    }
                }
                catch (IOException)
                {
                    throw new IndexOutOfRangeException();
                }
                finally
                {
                    streamReader.Close();
                }
                StreamWriter streamWriter = new StreamWriter(GetFullPath());
                try
                {
                    streamWriter.Write(content);
                }
                catch (IOException except)
                {
                    throw except;
                }
                finally
                {
                    streamWriter.Close();
                }
            }
        }

        public void Add(string line)
        {
            StreamWriter streamWriter = new StreamWriter(GetFullPath(), true);
            if (_count > 0)
            {
                streamWriter.Write("\r\n" + line);
            }
            else
            {
                streamWriter.Write(line);
            }
            streamWriter.Close();
            if (_count < 0)
            {
                _count = 0;
            }
            _count++;
        }

        /* Etudier le code et le retravailler afin d'éviter les lectures vides */
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

        /* Retravailler le code pour éviter de rajouter un saut de ligne en fin d'écriture */
        public void WriteFile(List<string> content)
        {
            StreamWriter streamWriter = new StreamWriter(GetFullPath(), false);
            foreach (string line in content)
            {
                streamWriter.WriteLine(line);
            }
            streamWriter.Close();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new TextFileIEnumerator(GetFullPath());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class TextFileIEnumerator : IEnumerator<string>
    {
        private StreamReader _streamReader;
        private string _line;

        public TextFileIEnumerator(string fileName)
        {
            _streamReader = new StreamReader(fileName);
            _line = null;
        }

        public string Current => _line;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _streamReader.Close();
        }

        public bool MoveNext()
        {
            bool forwarded;
            if (!_streamReader.EndOfStream)
            {
                _line = _streamReader.ReadLine();
                forwarded = true;
            }
            else
            {
                _line = null;
                forwarded = false;
            }
            return forwarded;
        }

        public void Reset()
        {
            _streamReader.DiscardBufferedData();
            _line = null;
        }
    }
}
