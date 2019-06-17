using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_RPG
{
    public class WorldMap
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/

        public int Id { get; set; }

        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private string _path;
        public string Path { get { return _path; } set { _path = @"" + value; } }

        private string _file;
        public string File { get { return _file; } set { _file = value; } }

        private string _walls;
        public string Walls { get { return _walls; } set { _walls = value; } }

        private List<StringBuilder> _map;

        [NotMapped]
        public int Width { get { return _map[0].Length; } }
        [NotMapped]
        public int Height { get { return _map.Count; } }

        [NotMapped]
        public int MaxAbscissa { get { return _map[0].Length - 1; } }
        [NotMapped]
        public int MaxOrdinate { get { return _map.Count - 1; } }

        private List<Interest> _doorways;
        [InverseProperty("Map")]
        virtual public List<Interest> Doorways // database InverseProperty
        {
            get { return _doorways; }
            set { _doorways = value; }
        }

        // Possible de globaliser ainsi de façon qu'un Id de WorldMap ou un Id de Quest
        // ou un Id d'autre chose puisse référencer la valeur de la clé étrangère ?

        //private List<Interest> _doorways;
        //[InverseProperty("Target")]
        //virtual public List<Interest> Doorways // database InverseProperty
        //{
        //    get { return _doorways; }
        //    set { _doorways = value; }
        //}

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
            _map = new List<StringBuilder>();
            Load();
        }

        private void Load()
        {
            TextFile mapFile = new TextFile(_path, _file);
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

        //public void SetContentAt(int abscissa, int ordinate, char avatar)
        //{
        //    _map[ordinate][abscissa] = avatar;
        //}

        //public void SetContentAt(Displayable displayable)
        //{
        //    _map[displayable.Ordinate][displayable.Abscissa] = displayable.Avatar;
        //}

        //public char GetContentAt(int abscissa, int ordinate)
        //{
        //    return _map[ordinate][abscissa];
        //}

        public char GetContentAt(Coordinates coordinates)
        {
            return _map[coordinates.Ordinate][coordinates.Abscissa];
        }

        public bool IsWall(Coordinates coordinates)
        {
            return _walls.Contains(GetContentAt(coordinates));
        }

        // isDoorway
        public int HasTriggerOn(Coordinates coordinates)
        {
            // A retravailler
            bool isDoorway = false;
            int index = -1;
            for (int i = 0; i < _doorways.Count && !isDoorway; i++)
            {
                isDoorway = _doorways[i].IsTriggered(coordinates);
                index = isDoorway ? i : -1;
            }
            return index;
        }

        // getDoorwayTarget
        public string GetTriggerTarget(Coordinates coordinates)
        {
            int index = HasTriggerOn(coordinates);
            return (index < 0) ? null : _doorways[index].Name;
        }

    }
}
