using BrickSchema.Net.EntityProperties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrickSchema.Net.Behaviors
{
    public class BehaviorValue
    {
        
        public string BehaviorId { get; set; } = string.Empty;
        public string BehaviorName { get; set; } = string.Empty;
        public string BehaviorType { get; set; } = string.Empty;
        public string BehaviorMode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public double Weight { get; set; } = 1;

        public List<BehaviorValue> Histories { get; set; } = new();

        public BehaviorValue()
        {

        }
        public BehaviorValue (string valueName, BrickBehavior behavior)
        {
            BehaviorId = behavior.Id;
            Name =valueName;
            Type = string.Empty;
            BehaviorName = behavior.Name;
            BehaviorType = behavior?.Type ?? string.Empty;
            BehaviorMode = behavior?.BehaviorMode ?? string.Empty;
            Value = string.Empty;
            Weight = behavior?.Weight??1;
        }

        public BehaviorValue(string valueName, string behaviorId, string behaviorName, string behaviorType, string behaviorMode, double weight = 1)
        {
            BehaviorId = behaviorId;
            Name = valueName;
            Type = string.Empty;
            BehaviorName = behaviorName;
            BehaviorType = behaviorType;
            BehaviorMode = behaviorMode;
            Value = string.Empty;
            Weight = weight;

            Histories = new();
        }

        public BehaviorValue(PropertiesEnum valueName, string behaviorId, string behaviorName, string behaviorType, string behaviorMode, double weight = 1)
        {
            BehaviorId = behaviorId;
            Name = valueName.ToString();
            Type = string.Empty;
            BehaviorName = behaviorName;
            BehaviorType = behaviorType;
            BehaviorMode = behaviorMode;
            Value = string.Empty;
            Weight = weight;

            Histories = new();
        }

        public BehaviorValue Clone(bool includeHistories = true)
        {
            BehaviorValue clone = new()
            {
                BehaviorId = BehaviorId,
                Name = Name,
                Type = Type,
                BehaviorType = BehaviorType,
                BehaviorMode = BehaviorMode,
                Value = Value,
                Weight = Weight,
               
            };
            clone.Histories = new();
            if (includeHistories)
            {
                foreach (var his in Histories)
                {
                    clone.Histories.Add(his.Clone());
                }
            }
            return clone;
        }

        public void SetValue<T>(T value)
        {
            if (value == null) { Console.WriteLine($"Property Set Value [{this.Name}:null]"); return; }
            try
            {
                this.Type = Helpers.EntityUntils.GetTypeName<T>();
                this.Value = JsonConvert.SerializeObject(value);
                this.Timestamp= DateTime.Now;
                BehaviorValue behaviorResult = Clone(false);
                behaviorResult.Histories = new();
                Histories.Add(behaviorResult);

            }
            catch (Exception ex) { Console.WriteLine($"Property Set Value [{this.Name}:{ex.Message}]"); }
        }

        public void UpdateValue(BehaviorValue value)
        {
            if (BehaviorId == value.BehaviorId)
            {
                Type = value.Type;
                Value = value.Value;
                Timestamp = value.Timestamp;
                BehaviorValue behaviorResult = Clone(false);
                behaviorResult.Histories = new();
                Histories.Add(behaviorResult);
            }
        }
        public T? GetValue<T>()
        {
            if (Type == null) return default(T);

            string tName = Helpers.EntityUntils.GetTypeName<T>();
            //if (!Type.Equals(tName)) throw new InvalidCastException($"Cannot convert {Type} to {tName}.");
            try
            {
                T? deserializedObject = JsonConvert.DeserializeObject<T>(this.Value);
                return deserializedObject;
            }
            catch (Exception ex) { Console.WriteLine($"Cannot convert {Type} to {tName}. {ex.Message}"); }
            return default(T?);
        }

        public (T? Value, U? Weight) GetValue<T, U>()
        {
            if (Type == null) return (default(T), default(U));
            
            string tName = Helpers.EntityUntils.GetTypeName<T>();
            string uName = Helpers.EntityUntils.GetTypeName<U>();
             
           
            //if (!Type.Equals(tName)) throw new InvalidCastException($"Cannot convert {Type} to {tName}.");
            try
            {
                T? deserializedObject = JsonConvert.DeserializeObject<T>(this.Value);
                U? weight = default(U);
                if (!IsNumericType(uName) || typeof(U) == typeof(string))
                {
                    weight = (U)Convert.ChangeType(Weight, typeof(U));
                    return (deserializedObject, weight);
                } else
                {
                    return (deserializedObject, default(U));
                }
            }
            catch (Exception ex) { Console.WriteLine($"Cannot convert {Type} to {tName}. {ex.Message}"); }
            return (default(T?), default(U));
        }

        

        public bool IsNumericType(string type)
        {
            if (string.IsNullOrEmpty(type))
                return false;
            type = type.ToLower();
            return type.Contains("byte") ||
                   type.Contains("sbyte") ||
                   type.Contains("short") ||
                   type.Contains("(ushort") ||
                   type.Contains("(int") ||
                   type.Contains("(uint") ||
                   type.Contains("long") ||
                   type.Contains("ulong") ||
                   type.Contains("float") ||
                   type.Contains("double") ||
                   type.Contains("decimal");
        }
    }
}
