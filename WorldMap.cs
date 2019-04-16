using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class WorldMap
    {
        private string _mapName;

        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        private char[][] _mapMatrix;

        public char[][] MapMatrix
        {
            get { return _mapMatrix; }
            set { _mapMatrix = value; }
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