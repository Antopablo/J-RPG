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
    class JsonFile
    {
        private DataContractJsonSerializer _formatterDCJS;

        private Stream _stream;

        public JsonFile() { }

        public void WorldMapSerialize(string path, string file, WorldMap map)
        {
            _stream = new StreamWriter(path + @"\" + file + "-Metadata.json").BaseStream;
            _formatterDCJS = new DataContractJsonSerializer(typeof(WorldMap));
            _formatterDCJS.WriteObject(_stream, map);
            _stream.Close();
        }

        public WorldMap WorldMapDeserialize(string path, string file)
        {
            _stream = new StreamReader(path + @"\" + file + "-Metadata.json").BaseStream;
            _formatterDCJS = new DataContractJsonSerializer(typeof(WorldMap));
            WorldMap map = (WorldMap)_formatterDCJS.ReadObject(_stream);
            _stream.Close();
            return map;
        }
    }
}
