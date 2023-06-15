using BrickSchema.Net.Relationships;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public class BrickBehavior : BrickEntity
    {
        protected ILogger? _logger;
        public string Name { get { return GetProperty<string>("Name")??string.Empty; } }
        protected bool IsRunning { get { return GetProperty<bool>("Running"); } }
        protected int PollRate
        {
            get
            {
                return GetProperty<int>("PollRate");
            }

            set
            {
                AddOrUpdateProperty("PoolRate", value);
            }

        }
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
        public BrickBehavior(string name, string type, ILogger? logger = null)
        {
            AddOrUpdateProperty("Name", name);
            AddOrUpdateProperty("Running", false);
            Type = type;
            _logger = logger;

            
        }



        #region Logger
        public void SetLogger(ILogger? logger)
        {
            _logger = logger;
        }

        #endregion Logger

        #region Virtual Functions
        public virtual void OnTimerTick(object? state) { }

        // Add a virtual Start method
        public virtual void Start()
        {

            AddOrUpdateProperty("Running", true);
            // Default implementation does nothing
        }

        // Add a virtual Stop method
        public virtual void Stop()
        {
            AddOrUpdateProperty("Running", false);
            // Default implementation does nothing
        }

        public virtual dynamic? Execute(params dynamic[] args)
        {
            // Default implementation does nothing
            return 0;
        }

        #endregion Virtual Functions




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
