using BrickSchema.Net.Behaviors;
using BrickSchema.Net.EntityProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Keep namespace as BirckSchema.Net
namespace BrickSchema.Net
{
    /// <summary>
    /// This class is part of BrickEnity. Placing in this folder for organization purpose only.
    /// </summary>
    public partial class BrickEntity
    {

        public void SetBehaviorValue<T>(BrickBehavior behavior, string valueName, T value)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            var myValue = results?.FirstOrDefault(x=>x.Name== valueName && x.BehaviorId == behavior.Id);
            if (myValue == null)
            {
                myValue = new(valueName, behavior);
                myValue.SetValue(value);
                results?.Add(myValue);
            }  else
            {
                myValue.SetValue(value);
            }
            AddOrUpdateProperty(PropertiesEnum.BehaviorValues, results);
        }

        public void SetBehaviorValue(BehaviorValue value)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            var myValue = results?.FirstOrDefault(x => x.Name == value.Name && x.BehaviorId == value.BehaviorId);
            if (myValue == null)
            {
                myValue = value.Clone(false);
                results?.Add(myValue);
            }
            else
            {
                myValue.UpdateValue(value);
            }
            AddOrUpdateProperty(PropertiesEnum.BehaviorValues, results);
        }

        public void SetBehaviorValue(List<BehaviorValue> values)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            foreach (var value in values)
            {
                var myValue = results?.FirstOrDefault(x => x.Name == value.Name && x.BehaviorId == value.BehaviorId);
                if (myValue == null)
                {
                    myValue = value.Clone(false);
                    results?.Add(myValue);
                }
                else
                {
                    myValue.UpdateValue(value);
                }
            }
            AddOrUpdateProperty(PropertiesEnum.BehaviorValues, results);
        }

        public BehaviorValue? GetBehaviorValue(string  behaviorId, string valueName)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            var myValue = results?.FirstOrDefault(x => x.Name == valueName && x.BehaviorId == behaviorId);
            return myValue;
        }
        public T? GetBehaviorValue<T>(string behaviorId, string valueName)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            var myValue = results?.FirstOrDefault(x => x.Name == valueName && x.BehaviorId == behaviorId);
            T? returnValue = default(T);
            if (myValue != null)
            {
                returnValue = myValue.GetValue<T>();
            }

            return returnValue;
        }

        public (T? Value, U? Weight)  GetBehaviorValue<T, U>(string behaviorId, string valueName)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            var myValue = results?.FirstOrDefault(x => x.Name == valueName && x.BehaviorId == behaviorId);
            (T?, U?) returnValue = (default(T), default(U));
            if (myValue != null)
            {
                returnValue = myValue.GetValue<T, U>();
            }

            return returnValue;
        }

        public List<BehaviorValue> GetBehaviorValues(string behaviorId)
        {
            var results = GetProperty<List<BehaviorValue>>(PropertiesEnum.BehaviorValues);
            if (results == null) results = new();
            var myValues = results?.Where(x => x.BehaviorId == behaviorId).ToList()??new();
            return myValues;
        }


        public void AddOrUpdateProperty<T>(string propertyName, T propertyValue)
        {
            var properties = Properties.Where(x => x.Name.Equals(propertyName)).ToList();
            EntityProperty? property = null;
            if (properties.Count > 1)
            {
                for (int i = 1; i < properties.Count; i++)
                { //keep first property[0];=
                    Properties.Remove(properties[i]);

                }
                property = Properties.FirstOrDefault(x => x.Name.Equals(propertyName));
            }
            else
            {
                property = properties.FirstOrDefault();
            }

            if (property == null)
            {
                property = new EntityProperty();
                property.SetValue(propertyName, propertyValue);
                Properties.Add(property);
            }
            else
            {
                property.SetValue(propertyName, propertyValue);
            }
        }

        public void AddOrUpdateProperty<T>(PropertiesEnum property, T propertyValue)
        {
            AddOrUpdateProperty(property.ToString(), propertyValue);
        }
        public T? GetProperty<T>(string propertyName)
        {
            var properties = Properties.Where(x => x.Name.Equals(propertyName)).ToList();
            EntityProperty? property = null;
            if (properties.Count > 1)
            {
                for (int i = 1; i < properties.Count; i++)
                { //keep first property[0];=
                    Properties.Remove(properties[i]);

                }
                property = Properties.FirstOrDefault(x => x.Name.Equals(propertyName));
            }
            else
            {
                property = properties.FirstOrDefault();
            }

            if (property != null)
            {
                return property.GetValue<T>();
            }

            return default(T?);
        }

        public T? GetProperty<T>(PropertiesEnum property)
        {
            return GetProperty<T>(property.ToString());
        }



    }
}
