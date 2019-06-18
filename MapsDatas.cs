using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    static class MapsDatas
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Génération des WorldMap   ############*/
        /*############                             ############*/
        /*#####################################################*/

        // Variables pour la génération des WorldMap Metadata Json
        static private JsonFile _jsonFile = new JsonFile();

        static private string _path = @".\Maps";

        static private Dictionary<string, string> _mappingMapFile;

        static public void Initialize()
        {
            _mappingMapFile = new Dictionary<string, string>();
            _mappingMapFile.Add("Ifantasia", "World");
            _mappingMapFile.Add("Repaire du Gobelin", "GoblinDen");
        }

        // retourne la world map désérialisée
        static public WorldMap GetWorldMap(string mapName)
        {
            WorldMap worldMap;
            worldMap = _jsonFile.WorldMapDeserialize(_path, _mappingMapFile[mapName]);
            worldMap.Load();
            return worldMap;
        }

        // methode qui retourne les coordonnées d'apparition du player sur la map de
        // destination en fonction de la map de provenance

        static public Coordinates GetHall(string originMapName, WorldMap targetWorldMap)
        {
            return targetWorldMap.Doorways.FirstOrDefault(doorway => doorway.Name == originMapName).Triggers[2];
        }

        static public void CreateJsonMetadatas()
        {
            List<Coordinates> dongeonTriggers;
            List<Interest> dongeonDoorways;
            WorldMap worldMap;

            // Carte : Ifantasia / World
            dongeonTriggers = new List<Coordinates>();
            dongeonDoorways = new List<Interest>();
            // Triggers
            dongeonTriggers.Add(new Coordinates(291, 142));
            dongeonTriggers.Add(new Coordinates(292, 142));
            dongeonTriggers.Add(new Coordinates(293, 142));
            dongeonTriggers.Add(new Coordinates(294, 142));
            dongeonTriggers.Add(new Coordinates(295, 142));
            // Doorways
            dongeonDoorways.Add(new Interest("Repaire du Gobelin", dongeonTriggers));
            // WorldMap
            worldMap = new WorldMap("Ifantasia", _path, "World", "☼╣║╗╝╚╔╩╦╠═╬█", dongeonDoorways);
            // Sérialisation
            _jsonFile.WorldMapSerialize(_path, "World", worldMap);

            // Carte : Repaire du Gobelin / GoblinDen
            dongeonTriggers.Clear();
            dongeonDoorways.Clear();
            // Triggers
            dongeonTriggers.Add(new Coordinates(86, 49));
            dongeonTriggers.Add(new Coordinates(87, 49));
            dongeonTriggers.Add(new Coordinates(88, 49));
            dongeonTriggers.Add(new Coordinates(89, 49));
            dongeonTriggers.Add(new Coordinates(90, 49));
            // Doorways
            dongeonDoorways.Add(new Interest("Ifantasia", dongeonTriggers));
            // WorldMap
            worldMap = new WorldMap("Repaire du Gobelin", _path, "GoblinDen", "☼╣║╗╝╚╔╩╦╠═╬█", dongeonDoorways);
            // Sérialisation
            _jsonFile.WorldMapSerialize(_path, "GoblinDen", worldMap);
        }

    }
}
