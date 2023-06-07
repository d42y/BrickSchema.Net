using BrickSchema.Net.Relationships;

namespace BrickSchema.Net.Classes.Equipments
{
    public class Meter : Equipment {

        
        public List<BrickEntity> HasSubMeter()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(SubmeterOf).Name) ?? false && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }
    }
}
