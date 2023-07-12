using Newtonsoft.Json;


namespace BrickSchema.Net.EntityProperties
{
    public class EntityProperty
    {
        public string Id { get; set; }
        public string? Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public EntityProperty Clone()
        {
            var clone = new EntityProperty();
            clone.Id = Id;
            clone.Type = Type;
            clone.Name = Name;
            clone.Value = Value;
            return clone;
        }
        public EntityProperty()
        {
            Id = Guid.NewGuid().ToString();
            Type = null;
            Name = string.Empty;
            
        }

        [JsonConstructor]
        public EntityProperty(string id, string type, string name, string value)
        {
            Id = id;
            Type = type;
            Name = name;
            Value = value;

        }

        public void SetValue<T> (string name, T value)
        {
            if (value == null) { Console.WriteLine($"Property Set Value [{name}:null]"); return; }
            try
            {
                this.Type = GetTypeName<T>();
                this.Name = name;
                this.Value = JsonConvert.SerializeObject(value);
            } catch (Exception ex) { Console.WriteLine($"Property Set Value [{name}:{ex.Message}]"); }
        }

        

        public T? GetValue<T> ()
        {
            if (Type == null) return default(T);

            string tName = GetTypeName<T>();
            //if (!Type.Equals(tName)) throw new InvalidCastException($"Cannot convert {Type} to {tName}.");
            try
            {
                T? deserializedObject = JsonConvert.DeserializeObject<T>(this.Value);
                return deserializedObject;
            } catch (Exception ex) { /* throw new InvalidCastException($"Cannot convert {Type} to {tName}. {ex.Message}");*/ }
            return default(T?);
        }

        private string GetTypeName<T>()
        {
            string tName = typeof(T).Name;
            if (tName.StartsWith("Nullable"))
            {
                Type nullableType = typeof(T?);
                Type underlyingType = Nullable.GetUnderlyingType(nullableType);
                tName = underlyingType.Name;

            }
            return tName;
        }

    }
}
