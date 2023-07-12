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
            foreach (var behavior in behaviors)
            {
                behavior.Stop();
                Behaviors.Remove(behavior);
            }
        }

        public void RemoveBehavior(BrickBehavior behavior)
        {
            Behaviors.Remove(behavior);
        }

        public List<BrickBehavior> GetBehaviors()
        {
            return Behaviors;
        }

        public List<BrickBehavior> GetBehaviors(string type)
        {
            return Behaviors.Where(x => x.Type == type).ToList();
        }

    }
}
