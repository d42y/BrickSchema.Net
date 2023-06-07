using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BrickSchema.Net
{
    public static class BrickSchemaUtility
    {
        public static List<dynamic> ImportBrickSchema(string jsonLdFilePath)
        {

            //List<dynamic> entities = new List<dynamic>();
            //if (File.Exists(jsonLdFilePath))
            //{
            //    // Read the JSON-LD file
            //    string jsonLd = File.ReadAllText(jsonLdFilePath);
            //    JObject jsonLdObject = JObject.Parse(jsonLd);

            //    // Extract the entities from the JSON-LD graph
            //    JArray graph = (JArray)jsonLdObject["@graph"];

            //    // Deserialize each entity in the graph
            //    foreach (JObject entity in graph)
            //    {
            //        // Deserialize the entity and add it to the list
            //        BrickEntity brickEntity = entity.ToObject<BrickEntity>();

            //        entities.Add(brickEntity);
            //    }
            //}
            //return entities;
            string json = string.Empty;
            if (File.Exists(jsonLdFilePath))
            {
                json = File.ReadAllText(jsonLdFilePath);
            }
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All, Formatting = Newtonsoft.Json.Formatting.Indented };
            return JsonConvert.DeserializeObject<List<dynamic>>(json, settings)??new();
        }

        public static void ExportBrickSchema(List<dynamic> entities, string jsonLdFilePath)
        {
            //// Create a JSON-LD graph from the list of entities
            //JArray graph = new JArray();

            //foreach (dynamic entity in entities)
            //{
            //    // Serialize the entity and add it to the graph
            //    JObject jsonEntity = JObject.FromObject(entity);
            //    graph.Add(jsonEntity);
            //}

            //// Create a JSON-LD object with the graph
            //JObject jsonLdObject = new JObject
            //{
            //    { "@context", "https://brickschema.org/schema/1.0.3/Brick.jsonld" },
            //    { "@graph", graph }
            //};

            //// Write the JSON-LD object to a file
            //File.WriteAllText(jsonLdFilePath, jsonLdObject.ToString(Newtonsoft.Json.Formatting.Indented));
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All, Formatting = Newtonsoft.Json.Formatting.Indented };
            JsonConvert.SerializeObject(entities, settings);
            File.WriteAllText(jsonLdFilePath, JsonConvert.SerializeObject(entities, settings));
        }
    }
}
