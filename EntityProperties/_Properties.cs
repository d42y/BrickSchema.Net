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
