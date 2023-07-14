using BrickSchema.Net.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes
{
    //location class

    public class Location : BrickClass
    {
        public Location() 
        {
            AddOrUpdateProperty(EntityProperties.PropertiesEnum.BrickClass, typeof(Location).Name);
        }
        public List<BrickEntity> GetEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(LocationOf).Name) ?? false && relationship.ParentId == Id))
            .ToList();
            return entities;
        }

    }

    
}
