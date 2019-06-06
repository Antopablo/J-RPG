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
    class WorldMap
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<string> _map;

        public List<string> Map
        {
            get { return _map; }
            set { _map = value; }
        }

        private Coordinate _enter;

        public Coordinate Enter
        {
            get { return _enter; }
            set { _enter = value; }
        }

        private Coordinate _exit;

        public Coordinate Exit
        {
            get { return _exit; }
            set { _exit = value; }
        }

        private Coordinate _lastPlayerPosition;

        public Coordinate LastPlayerPosition
        {
            get { return _lastPlayerPosition; }
            set { _lastPlayerPosition = value; }
        }

        private StringBuilder _mapString;

        public StringBuilder MapString
        {
            get { return _mapString; }
            set { _mapString = value; }
        }

        public WorldMap(string fileName)
        {
            //_mapMatrix = new string[201,101];
        }

        // private methode de construction de chaine de caractere
    }
}
/*
static Dictionary<string, List<Livre>> LoadJsonFile()
{
    Dictionary<string, List<Livre>> inventaires;
    string path = @"..\..\..\Test\JsonFiles\";
    DataContractJsonSerializer dataContractJsonSerializer;
    Stream stream = new StreamReader(path + "inventaires.json").BaseStream;
    List<Type> types = new List<Type>();
    types.Add(typeof(String));
    types.Add(typeof(Livre));
    dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Dictionary<string, List<Livre>>));
    inventaires = (Dictionary<string, List<Livre>>)dataContractJsonSerializer.ReadObject(stream);
    stream.Close();
    return inventaires;
}

static void SaveJsonFile(Dictionary<string, List<Livre>> inventaires)
{
    string path = @"..\..\..\Test\JsonFiles\";
    DataContractJsonSerializer dataContractJsonSerializer;
    Stream stream = new StreamWriter(path + "inventaires.json").BaseStream;
    List<Type> types = new List<Type>();
    types.Add(typeof(String));
    types.Add(typeof(Livre));
    dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Dictionary<string, List<Livre>>), types);
    dataContractJsonSerializer.WriteObject(stream, inventaires);
    stream.Close();
}
*/