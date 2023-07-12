using BrickSchema.Net.Relationships;
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

        public T AddRelationship<T>(string parentId) where T : BrickRelationship, new()
        {
            T relationship = new T
            {
                Id = Guid.NewGuid().ToString(),
                Type = typeof(T).Name,
                ParentId = parentId,
            };

            Relationships.Add(relationship);
            return relationship;
        }

        public List<BrickRelationship> GetRelationships()
        {
            return Relationships;
        }

        //Relationship
        public AssociatedWith AddRelationshipAssociatedWith(string parentId) => AddRelationship<AssociatedWith>(parentId);
        public Fedby AddRelationshipFedBy(string parentId) => AddRelationship<Fedby>(parentId);

        public LocationOf AddRelationshipLocationOf(string parentId) => AddRelationship<LocationOf>(parentId);

        public MeterBy AddRelationshipMeterBy(string parentId) => AddRelationship<MeterBy>(parentId);

        public PointOf AddRelationshipPointOf(string parentId) => AddRelationship<PointOf>(parentId);

        public PartOf AddRelationshipPartOf(string parentId) => AddRelationship<PartOf>(parentId);

        public TagOf AddRelationshipTagOf(string parentId) => AddRelationship<TagOf>(parentId);

        public SubmeterOf AddRelationshipSubmeterOf(string parentId) => AddRelationship<SubmeterOf>(parentId);



    }
}
