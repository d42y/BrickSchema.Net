using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.EntityProperties
{
    public class EntityProperty
    {
        public string Id { get; set; }
        public string? Type { get; private set; }
        public string Name { get; private set; }
        public dynamic Value { get; private set; }

        public EntityProperty()
        {
            Id = Guid.NewGuid().ToString();
            Type = null;

        }

        [JsonConstructor]
        public EntityProperty(string id, string type, string name, dynamic value)
        {
            Id = id;
            Type = type;
            Name = name;
            Value = value;

        }

        public void SetValue (string name, dynamic value)
        {
            
            this.Type = value.GetType().Name;
            this.Name = name;
            this.Value = value;
        }

        

        public T? GetValue<T> ()
        {
            if (Type == null) return default(T);
            switch (this.Type)
            {
                default:
                    return (T)this.Value;
                    
            }
            
        }



    }
}
