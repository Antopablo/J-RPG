using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace J_RPG
{
    [DataContract]
    class WorldMap
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/


        private string _name;
        [DataMember]
        public string Name { get { return _name; } set { _name = value; } }

        private string _path;
        [DataMember]
        public string Path { get { return _path; } set { _path = @"" + value; } }

        private string _file;
        [DataMember]
        public string File { get { return _file; } set { _file = value; } }

        private string _walls;
        [DataMember]
        public string Walls { get { return _walls; } set { _walls = value; } }

        private List<Interest> _doorways;
        [DataMember]
        public List<Interest> Doorways { get { return _doorways; } set { _doorways = value; } }

        private List<StringBuilder> _map;

        public int Width { get { return _map[0].Length; } }
        public int Height { get { return _map.Count; } }

        public int MaxAbscissa { get { return _map[0].Length - 1; } }
        public int MaxOrdinate { get { return _map.Count - 1; } }

        /*#####################################################*/
        /*############                             ############*/
        /*############  Constructeurs et méthodes  ############*/
        /*############                             ############*/
        /*#####################################################*/


        public WorldMap() { }

        public WorldMap(string name, string path, string file, string walls, List<Interest> doorways)
        {
            Name = name;
            Path = @"" + path;
            File = file;
            Walls = walls;
            Doorways = doorways;
            Load();
        }

        public void Load()
        {
            _map = new List<StringBuilder>();
            TextFile mapFile = new TextFile(@"" + _path, _file);
            foreach (string line in mapFile)
            {
                _map.Add(new StringBuilder(line));
            }
        }

        public List<StringBuilder> GetSubPart(int abscissa, int ordinate, int width, int height)
        {
            List<StringBuilder> subPart = new List<StringBuilder>();
            for (int j = 0; j < height; j++)
            {
                subPart.Add(new StringBuilder(_map[ordinate + j].ToString(abscissa, width)));
            }
            return subPart;
        }

        public char GetContentAt(Coordinates coordinates)
        {
            return _map[coordinates.Ordinate][coordinates.Abscissa];
        }

        public bool IsWall(Coordinates coordinates)
        {
            return _walls.Contains(GetContentAt(coordinates));
        }


        public bool IsDoorway(Coordinates coordinates)
        {
            return _doorways.Exists(doorway => doorway.IsTriggered(coordinates));
        }

        // getDoorwayTarget
        public string DoorwayTarget(Coordinates coordinates)
        {
            return _doorways.First(doorway => doorway.IsTriggered(coordinates)).Name;
        }

    }
}
