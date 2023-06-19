using Newtonsoft.Json;


namespace BrickSchema.Net.EntityProperties
{
    public class EntityProperty
    {
        public string Id { get; set; }
        public string? Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

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
            if (value == null) { throw new ArgumentNullException("value"); }
            try
            {
                this.Type = GetTypeName<T>();
                this.Name = name;
                this.Value = JsonConvert.SerializeObject(value);
            } catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        

        public T? GetValue<T> ()
        {
            if (Type == null) return default(T);

            string tName = GetTypeName<T>();
            if (!Type.Equals(tName)) throw new InvalidCastException($"Cannot convert {Type} to {tName}.");
            try
            {
                T? deserializedObject = JsonConvert.DeserializeObject<T>(this.Value);
                return deserializedObject;
            } catch (Exception ex) { throw new InvalidCastException($"Cannot convert {Type} to {tName}. {ex.Message}"); }
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
