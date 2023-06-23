using BrickSchema.Net.EntityProperties;
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

        
        

        #region Private properties
        private Thread _executionThread;
        private bool _executing = false;
        #endregion private properties

        #region Protected properties
        protected CancellationTokenSource CancelToken;
        protected ILogger? _logger;
        protected bool IsRunning { get { return GetProperty<bool>(PropertiesEnum.Running); } }

        

        protected DateTime LastRun = DateTime.Now;
        protected bool Processing = false;

        protected Dictionary<string, DateTime> Errors = new Dictionary<string, DateTime>();

        #endregion protected properties

        #region Public properties
        public string BehaviorType { 
            get { return GetProperty<string>(PropertiesEnum.BehaviorType) ?? string.Empty; }
        }

        public string Name { get { return GetProperty<string>(PropertiesEnum.Name)??string.Empty; } }
        public string Description { get { return GetProperty<string>(PropertiesEnum.Description) ?? string.Empty; } }
        public string Insight { get { return GetProperty<string>(PropertiesEnum.Insight) ?? string.Empty; } }
        public string Resolution { get { return GetProperty<string>(PropertiesEnum.Resoltuion) ?? string.Empty; } }
        public DateTime LastExecutionStart 
        { 
            get 
            { 
                var d = GetProperty<DateTime?>(PropertiesEnum.LastExecutionStart);
                if (d == null)
                {
                    d = DateTime.Now;
                    AddOrUpdateProperty(PropertiesEnum.LastExecutionStart, d);
                }
                return (DateTime)d;  
            } 
        }
        public DateTime LastExecutionEnd
        {
            get
            {
                var d = GetProperty<DateTime?>(PropertiesEnum.LastExecutionEnd);
                if (d == null)
                {
                    d = DateTime.Now;
                    AddOrUpdateProperty(PropertiesEnum.LastExecutionEnd, d);
                }
                return (DateTime)d;
            }
        }

        public double Weight
        {
            get
            {
                var w = GetProperty<double>(PropertiesEnum.Weight);
                return w == 0 ? 1: w;
            }
        }

        public BrickEntity? Parent = null;
        #endregion public properties

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

            AddOrUpdateProperty(PropertiesEnum.Errors, Errors);
            AddOrUpdateProperty(PropertiesEnum.HasError, true);
            return answer;
        }


        protected void ClearErrors()
        {
            Errors.Clear();
            AddOrUpdateProperty(PropertiesEnum.HasError, false);
        }

        public BrickBehavior( string entityType, string behaviorType, string behaviorName, ILogger? logger = null)
        {
            AddOrUpdateProperty(PropertiesEnum.Name, behaviorName);
            AddOrUpdateProperty(PropertiesEnum.Running, false);
            AddOrUpdateProperty(PropertiesEnum.Weight, 1); //to do
            Type = entityType;
            AddOrUpdateProperty(PropertiesEnum.BehaviorType, behaviorType);
            _logger = logger;
            _executing = false;
            _executionThread = new Thread(Execute);
        }



        #region Logger
        public void SetLogger(ILogger? logger)
        {
            _logger = logger;
        }

        #endregion Logger

        #region CallBack
        public void OnTimerTick()
        {
            if (!_executing && IsRunning && !_executionThread.IsAlive)
            {
                _executing = true;
                AddOrUpdateProperty(PropertiesEnum.LastExecutionStart, DateTime.Now);
                try
                {
                    //CancelToken = new CancellationTokenSource();
                    //_executionThread = new Thread(Execute);
                    //_executionThread.Start();
                    //_executionThread.Join();
                    Execute();
                    AddOrUpdateProperty(PropertiesEnum.ExecutionReturnCode, 0);
                } catch (Exception ex)
                {
                    AddOrUpdateProperty(PropertiesEnum.ExecutionReturnCode, 100);
                    AddOrUpdateProperty(PropertiesEnum.ExecutionExceptionMessage, ex.Message);
                    _logger?.LogError(ex, $"Bahavior OnTimerTick: Excpetion: {ex.Message}");
                }
                AddOrUpdateProperty(PropertiesEnum.LastExecutionEnd, DateTime.Now);
                _executing = false;
            }
        }

        public void Start()
        {

            AddOrUpdateProperty(PropertiesEnum.Running, true);
            Load();
            // Default implementation does nothing
        }

        // Add a virtual Stop method
        public void Stop()
        {
            AddOrUpdateProperty(PropertiesEnum.Running, false);
            CancelToken?.Cancel();
            Unload();
            // Default implementation does nothing
        }
        #endregion callback

        #region Virtual Functions


        // Add a virtual Start method

        
        protected virtual void Execute()
        {
            // Default implementation does nothing
      
        }

        protected virtual void Load()
        {

        }

        protected virtual void Unload() { }

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
