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
            
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All, Formatting = Newtonsoft.Json.Formatting.Indented };
            JsonConvert.SerializeObject(entities, settings);
            File.WriteAllText(jsonLdFilePath, JsonConvert.SerializeObject(entities, settings));
        }
    }
}
