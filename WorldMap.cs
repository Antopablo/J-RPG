using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class WorldMap
    {
        public int Id { get; set; } // Pour la database

        private string _name;
        public string Name { get { return _name; } set { _name = value; } } // database

        private string _path;
        public string Path // database
        {
            get { return _path; }
            set { _path = @""+ value; }
        }

        private string _file;
        public string File // database
        {
            get { return _file; }
            set { _file = value; }
        }

        private List<MapAccess> _mapAccesses;
        public List<MapAccess> MapAccesses // database InverseProperty
        {
            get { return _mapAccesses; }
            set { _mapAccesses = value; }
        }

        private List<string> _map;

        public int Width { get { return _map[0].Length; } }
        public int Height { get { return _map.Count; } }

        public int MaxAbscissa { get { return _map[0].Length - 1; } }
        public int MaxOrdinate { get { return _map.Count - 1; } }

        public WorldMap() { }

        public WorldMap(string name, string path, string file, List<MapAccess> mapAccesses)
        {
            Name = name;
            Path = path;
            File = file;
            _map = new List<string>();
            _mapAccesses = mapAccesses;
            Load();
        }

        private void Load()
        {
            TextFile mapFile = new TextFile(_path, _file);
            foreach (string line in mapFile)
            {
                _map.Add(line);
            }
        }

        public List<StringBuilder> GetSubPart(int abscissa, int ordinate, int width, int height)
        {
            List<StringBuilder> subPart = new List<StringBuilder>();
            for (int j = 0; j < height; j++)
            {
                subPart.Add(new StringBuilder(_map[ordinate + j].Substring(abscissa, width)));
            }
            return subPart;
        }

        public string GetCharString(int abscissa, int ordinate)
        {
            return _map[ordinate][abscissa].ToString();
        }
    }
}
