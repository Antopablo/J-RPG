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
    class WorldMapFactory
    {

        public WorldMapFactory() { }

        public WorldMap CreateWorldMap(string jsonFileName)
        {
            // Create from a Json file
            WorldMap map = null;
            return map;
        }

        public void JsonCreator(string textFileName)
        {

        }
    }
}
