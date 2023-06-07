using BrickSchema.Net.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public class BrickBehavior : BrickEntity
    {
        public string Name { get; set; }
        protected bool IsRunning { get; set; } = false;
        protected int PollRate { get; set; } = 0;
        public BrickEntity? Parent { get; set; } = null;
        protected Timer? BehaviorTimer { get; set; } = null;

        protected Dictionary<string, DateTime> Errors = new Dictionary<string, DateTime>();

        protected bool NotifyError(string error)
        {
            bool answer = false;

            if (Errors.ContainsKey(error))
            {
                var ts = DateTime.Now - Errors[error];
                if (ts.TotalHours >= 24)
                {
                    answer = true;
                    Errors[error] = DateTime.Now;
                }
            } else
            {
                answer = true;
                Errors.Add(error, DateTime.Now);
            }

            return answer;
        }


        protected void ClearErrors()
        {
            Errors.Clear();
        }
        public BrickBehavior(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public virtual void OnTimerTick(object? state) { }

        // Add a virtual Start method
        public virtual void Start()
        {

            IsRunning = true;
            // Default implementation does nothing
        }

        // Add a virtual Stop method
        public virtual void Stop()
        {
            IsRunning = false;
            // Default implementation does nothing
        }

        public virtual dynamic? Execute(params dynamic[] args)
        {
            // Default implementation does nothing
            return 0;
        }

        public dynamic? AskAssociatedWith(params dynamic[] args) {  
            
            if (Parent == null) { return null; }

            return null; 
        }

        public dynamic? AskFedby(params dynamic[] args)
        {
            if (Parent == null) { return null; }

            return null;
        }

        public dynamic? AskMeterBy(params dynamic[] args)
        {
            if (Parent == null) { return null; }

            return null;
        }

        public dynamic? AskPartOf(params dynamic[] args)
        {
            if (Parent == null) { return null; }

            return null;
        }

        public dynamic? AskPointOfParent(string type, params dynamic[] args)
        {
            if (Parent == null) { return null; }
            var pointOfs = Parent.GetPointOfParent();
            foreach ( var point in pointOfs )
            {
                if ( point != null )
                {
                    var behaviors = point.Behaviors.Where(x => x.Type?.Equals(type) ?? false);
                    behaviors.Except(args);
                }
            }
            return null;
        }
    }
}
