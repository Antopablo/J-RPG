using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class Map
    {
        private string[,] _worldMap;

        public string[,] WorldMap
        {
            get { return _worldMap; }
            set { _worldMap = value; }
        }

        public Map(string fileName)
        {
            //_worldMap = new string[201,101];
        }
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