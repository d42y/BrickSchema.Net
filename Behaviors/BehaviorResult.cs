using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrickSchema.Net.Behaviors
{
    public class BehaviorResult
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string BehaviorName { get; set; }
        public string BehaviorType { get; set; }
        public string BehaviorMode { get; set; }
        public string Value { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public List<BehaviorResult> History { get; set; } = new();

        public BehaviorResult()
        {

        }
        public BehaviorResult (BrickBehavior behavior)
        {
            Id = behavior.Id;
            Name = behavior.Name;
            Type = behavior.Type;
            BehaviorType = behavior?.Type??string.Empty;
            BehaviorMode = behavior.BehaviorMode;
            Value = string.Empty;
        }

        public BehaviorResult (string id, string name, string type, string behaviorType, string behaviorMode, string value)
        {
            Id = id;
            Name = name;
            Type = type;
            BehaviorType = behaviorType;
            BehaviorMode = behaviorMode;
            SetValue(value);

            History.Add(Clone());
        }

        public BehaviorResult Clone()
        {
            BehaviorResult clone = new()
            {
                Id = Id,
                Name = Name,
                Type = Type,
                BehaviorType = BehaviorType,
                BehaviorMode = BehaviorMode,
                Value = Value,
            };
            return clone;
        }

        public void SetValue<T>(string name, T value)
        {
            if (value == null) { Console.WriteLine($"Property Set Value [{name}:null]"); return; }
            try
            {
                this.Type = GetTypeName<T>();
                this.Name = name;
                this.Value = JsonConvert.SerializeObject(value);
                this.Timestamp= DateTime.Now;
            }
            catch (Exception ex) { Console.WriteLine($"Property Set Value [{name}:{ex.Message}]"); }
        }

        public T? GetValue<T>()
        {
            if (Type == null) return default(T);

            string tName = GetTypeName<T>();
            //if (!Type.Equals(tName)) throw new InvalidCastException($"Cannot convert {Type} to {tName}.");
            try
            {
                T? deserializedObject = JsonConvert.DeserializeObject<T>(this.Value);
                return deserializedObject;
            }
            catch (Exception ex) { /* throw new InvalidCastException($"Cannot convert {Type} to {tName}. {ex.Message}");*/ }
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
