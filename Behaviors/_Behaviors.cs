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
        public BrickBehavior AddBehavior(BrickBehavior behavior)
        {

            var behaviors = GetBehaviors(behavior.Type);
            if (behaviors.Count >= 1)
            {
                for (int i = 0; i < behaviors.Count - 1; i++)
                {
                    RemoveBehavior(behaviors[i]);
                }
                var foundBehavior = behaviors[behaviors.Count - 1];
                if (foundBehavior.Parent == null) foundBehavior.Parent = this;
                return foundBehavior;

            }


            if (RegisteredBehaviors.ContainsKey(behavior.Type))
            {
                behavior.Id = RegisteredBehaviors[behavior.Type];
            }
            else
            {
                RegisteredBehaviors.Add(behavior.Type, behavior.Id);
            }

            behavior.Parent = this; //must set this before start
            behavior.Start();
            Behaviors.Add(behavior);
            return behavior;
        }

        public void RemoveBehavior(string type)
        {
            var behaviors = GetBehaviors(type);
            foreach (var behavior in behaviors??new())
            {
                behavior.Stop();
                Behaviors.Remove(behavior);
            }
        }

        public void RemoveBehavior(BrickBehavior behavior)
        {
            Behaviors.Remove(behavior);
        }

        public List<BrickBehavior> GetBehaviors(bool byReference = true)
        {
            if (byReference)
            {
                return Behaviors;
            }

            List<BrickBehavior> brickBehaviors = new();
            foreach(var b in Behaviors??new())
            {
                brickBehaviors.Add(b.Clone());
            }
            return brickBehaviors;
        }

        public List<BrickBehavior> GetBehaviors(string type, bool byReference = true)
        {
            var behaviors = Behaviors.Where(x => x.Type == type).ToList();
            if (byReference) return behaviors;

            List <BrickBehavior> brickBehaviors = new();
            foreach (var behavior in Behaviors)
            {
                brickBehaviors.Add(behavior.Clone());
            }
            return brickBehaviors;
        }

    }
}
