using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes
{
    public class Tag : BrickClass
    {

        public List<BrickEntity> GetEntities()
        {
            var entities = OtherEntities
                .Where(entity => entity.Relationships.Any(relationship => relationship.ParentId == Id))
                .ToList();
            return entities;
        }

    }

}
