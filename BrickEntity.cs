using BrickSchema.Net.Classes;
using BrickSchema.Net.EntityProperties;
using BrickSchema.Net.Relationships;
using BrickSchema.Net.Shapes;
using Newtonsoft.Json;
using System.Drawing;

namespace BrickSchema.Net
{
    public partial class BrickEntity
    {
        [JsonIgnore]
        internal List<BrickEntity> OtherEntities { get; set; }

        public string Id { get; set; }
        public string? Type { get; set; }
        public List<EntityProperty> Properties { get; set; }
        public List<BrickRelationship> Relationships { get; set; }
        
        public List<BrickShape> Shapes { get; set; }

        public Dictionary<string, string> RegisteredBehaviors { get; set; } //type, guid

        [JsonIgnore]
        public List<BrickBehavior> Behaviors { get; set; }

        public BrickEntity(BrickEntity entity)
        {
            var e = entity.Clone();
            Id = e.Id;
            Type = e.Type;
            Properties = e.Properties;
            Relationships = e.Relationships;
            Shapes = e.Shapes;
            RegisteredBehaviors = e.RegisteredBehaviors;
        }

        public BrickEntity()
        {
            OtherEntities = new List<BrickEntity>();
            Id = Guid.NewGuid().ToString();
            Properties = new List<EntityProperty>();
            Relationships = new List<BrickRelationship>();
            Shapes = new List<BrickShape>();
            RegisteredBehaviors = new Dictionary<string, string>();
            Behaviors = new List<BrickBehavior>();

            Type = null;
        }

        public virtual BrickEntity Clone()
        {
            var clone = new BrickEntity();
            clone.Id = Id;
            clone.Type = Type;
            foreach (var p in Properties ?? new())
            {
                clone.Properties.Add(p.Clone());
            }
            foreach (var r in Relationships ?? new())
            {
                clone.Relationships.Add(r.Clone());
            }
            clone.RegisteredBehaviors = new(RegisteredBehaviors);
            foreach (var b in Behaviors??new())
            {
                clone.Behaviors.Add(b.Clone());
            }
            foreach (var s in Shapes??new())
            {
                clone.Shapes.Add(s.Clone());
            }
            return clone;
        }
    
        public List<BrickEntity> GetChildEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(AssociatedWith).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            entities.AddRange(GetFedEntitites().Except(entities));
            entities.AddRange(GetMeterEntities().Except(entities));
            entities.AddRange(GetPartEntitites().Except(entities));
            entities.AddRange(GetPointEntities().Except(entities));
            return entities;
        }

        public List<BrickEntity> GetFedEntitites()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(Fedby).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetMeterEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(MeterBy).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }
        public List<BrickEntity> GetPartEntitites()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PartOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }
        public List<Classes.Point> GetPointEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PointOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();

            List<Classes.Point> points = new List<Classes.Point>();
            foreach (var entity in entities)
            {
                points.Add((Classes.Point)entity);
            }

            return points;
        }

        public List<Classes.Point> GetPointEntities(List<Tag> tags)
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PointOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();

            List<Classes.Point> points = new List<Classes.Point>();
            foreach (var entity in entities)
            {
                var foundTags = entity.GetTags();
                foreach (var tag in foundTags)
                {
                    if (tags.Any(x=>x.Type.Equals(tag.Type)))
                    {
                        points.Add((Classes.Point)entity);
                    }
                }
            }

            return points;
        }

        public Classes.Point? GetPointEntity(string tagName)
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PointOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();

            foreach (var entity in entities)
            {
                var foundTags = entity.GetTags();
                foreach (var tag in foundTags)
                {
                    if (tag.Name.Equals(tagName))
                    {
                        if (entity is Classes.Point)
                        {
                            return entity as Classes.Point;
                        }
                    }
                }
            }

            return null;
        }

        public List<Tag> GetTags()
        {
            var tags = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(TagOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            List<Tag> foundTags = new List<Tag>();
            foreach (var tag in tags)
            {
                foundTags.Add(tag as Tag);
            }
            return foundTags;
        }

        public List<BrickEntity> GetFeedingParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(Fedby).Name) ?? false))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetMeetingParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(MeterBy).Name) ?? false))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetPartOfParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(PartOf).Name) ?? false))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetPointOfParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(PointOf).Name) ?? false))
            .ToList();
            return entities;
        }



    }
}