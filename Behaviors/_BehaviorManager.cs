using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        public List<BrickBehavior> GetBehaviors(List<string> behaviorIds, bool byReference = true)
        {
            List<BrickBehavior> brickBehaviors = new List<BrickBehavior>();
            foreach (var entity in _entities)
            {
                var e = entity as BrickEntity;
                brickBehaviors.AddRange(e.GetBehaviors(byReference).Where(x => behaviorIds.Contains(x.Id) || behaviorIds.Count == 0));// e?.Behaviors.Where(x => behaviorIds.Contains(x.Id) || behaviorIds.Count == 0) ?? new List<BrickBehavior>());
            }

            return brickBehaviors;
        }

        public List<BrickBehavior> GetEquipmentBehaviors(string equipmentId, bool byReference = true)
        {
            var equipments = GetEquipments(new() { equipmentId });

            List<BrickBehavior> brickBehaviors = new();
            foreach (var entity in equipments)
            {
                var e = entity as BrickEntity;
                brickBehaviors.AddRange(e.GetBehaviors(byReference));

            }

            return brickBehaviors;
        }

        public Dictionary<string, string> GetRegisteredEquipmentBehaviors(string equipmentId, bool byReference = true)
        {
            var equipments = GetEquipments(new() { equipmentId });

            Dictionary<string, string> registeredBrickBehaviors = new();
            foreach (var entity in equipments)
            {
                var e = entity as BrickEntity;
                registeredBrickBehaviors = (e?.RegisteredBehaviors ?? new Dictionary<string, string>());
                break;
            }

            return byReference? registeredBrickBehaviors : new(registeredBrickBehaviors);
        }

    }
}
