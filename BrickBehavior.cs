using BrickSchema.Net.Behaviors;
using BrickSchema.Net.EntityProperties;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public class BrickBehavior : BrickEntity
    {

        
        #region Private properties
        private Thread? _executionThread;
        private bool _executing = false;
        private bool _executeByTimer = true;
        private bool _isTaskRunning = false;
        private bool _isAnalyticsRunning = false;
        private bool _isInfoRunning = false;
        private bool _isDescriptionRunning = false;
        private bool _isInsightRunning = false;
        private bool _isResolutionRunning = false;

        #endregion private properties

        #region Protected properties
        protected ILogger? _logger;
        
        protected CancellationTokenSource? CancelToken;


        protected DateTime LastRun = DateTime.Now;
        protected bool Processing = false;

        protected Dictionary<string, DateTime> Errors = new Dictionary<string, DateTime>();

        #endregion protected properties

        #region Public properties
        public bool IsRunning
        {
            get { return GetProperty<bool>(PropertiesEnum.Running); }
            protected set { AddOrUpdateProperty(PropertiesEnum.Running, value); }
        }
        public string BehaviorMode { 
            get { return GetProperty<string>(PropertiesEnum.BehaviorMode) ?? string.Empty; }
        }

        public string Name { get { return GetProperty<string>(PropertiesEnum.Name)??string.Empty; } }

        public string Description { 
            get { return GetProperty<string>(PropertiesEnum.Description) ?? string.Empty; } 
            protected set { AddOrUpdateProperty(PropertiesEnum.Description, value); }
        }
        public string Insight { 
            get { return GetProperty<string>(PropertiesEnum.Insight) ?? string.Empty; }
            protected set { AddOrUpdateProperty(PropertiesEnum.Insight, value); }
        }
        public string Resolution { 
            get { return GetProperty<string>(PropertiesEnum.Resoltuion) ?? string.Empty; }
            protected set { AddOrUpdateProperty(PropertiesEnum.Resoltuion, value); }
        }

        public string Info
        {
            get { return GetProperty<string>(PropertiesEnum.Info) ?? string.Empty; }
            protected set { AddOrUpdateProperty(PropertiesEnum.Info, value); }
        }
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

        private BrickBehavior(BrickEntity entity):base(entity) //this is for cloning only
        {

        } 

        public BrickBehavior(string behaviorMode, string behaviorName, double weight = 1, ILogger? logger = null)
        {
            AddOrUpdateProperty(PropertiesEnum.Name, behaviorName);
            AddOrUpdateProperty(PropertiesEnum.Running, false);
            AddOrUpdateProperty(PropertiesEnum.Weight, weight);
            Type = this.GetType().Name;
            AddOrUpdateProperty(PropertiesEnum.BehaviorMode, behaviorMode);
            _logger = logger;
            _executing = false;
            _executionThread = new Thread(Execute);
            CancelToken = new();
        }



        #region Logger
        public void SetLogger(ILogger? logger)
        {
            _logger = logger;
        }

        public bool IsLogger
        {
            get { return _logger != null; }
        }
        #endregion Logger


        #region public functions
        public override BrickBehavior Clone()
        {
            var clone = new BrickBehavior(base.Clone());
            //clone.Parent = Parent?.Clone();
            return clone;
        }

        public BehaviorValue SetConformance(double value)
        {
            AddOrUpdateProperty(PropertiesEnum.Conformance, value);
            BehaviorValue bv = new(PropertiesEnum.Conformance, Id, Name, Type, BehaviorMode);
            bv.SetValue(value);
            return bv;

        }

        public BehaviorValue SetBehaviorValue<T>(string valueName, T value)
        {
            AddOrUpdateProperty(valueName, value);
            BehaviorValue bv = new(valueName, Id, Name, Type, BehaviorMode);
            bv.SetValue(value);
            return bv;
        }

        public BehaviorValue SetBehaviorValue<T>(PropertiesEnum valueName, T value)
        {
            return SetBehaviorValue(valueName.ToString(), value);
        }
        
        #endregion public fucntions

        #region CallBack
        public void OnTimerTick()
        {
            if (_executeByTimer)
            {
                if (!_executing && IsRunning && !_executionThread.IsAlive)
                {
                    
                    try
                    {
                        CancelToken = new CancellationTokenSource();
                        _executionThread = new Thread(Execute);
                        _executionThread.Start();
                        _executionThread.Join();
                        
                    }
                    catch (Exception ex)
                    {
                       
                        _logger?.LogError(ex, $"Bahavior OnTimerTick: Excpetion: {ex.Message}");
                    }

                }
            }
        }

        public void Start()
        {

            IsRunning = true;
            Load();
            // Default implementation does nothing
        }

        // Add a virtual Stop method
        public void Stop()
        {
            IsRunning = false;
            Unload();
            // Default implementation does nothing
        }
        #endregion callback

        #region default Functions


        // Add a virtual Start method

        
        public void Execute()
        {
            if (!_executing)
            {
                _executing = true;
                try
                {
                    AddOrUpdateProperty(PropertiesEnum.LastExecutionStart, DateTime.Now);
                    // Default implementation does nothing
                    if (!_isTaskRunning)
                    {
                        _isTaskRunning = true;
                        try
                        {
                            var returnCode = ProcessTask(out List<BehaviorValue> values);
                            if (returnCode == BehaviorReturnCodes.Good)
                            {
                                Parent?.SetBehaviorValue(values);
                            }
                        }
                        catch { }
                        _isTaskRunning = false;
                    }
                    if (!_isAnalyticsRunning)
                    {
                        _isAnalyticsRunning = true;
                        try
                        {
                            var returnCode = ProcessAnalytics(out List<BehaviorValue> values);
                            if (returnCode == BehaviorReturnCodes.Good)
                            {
                                Parent?.SetBehaviorValue(values);
                            }
                        }
                        catch { }
                        _isAnalyticsRunning = false;
                    }
                    if (!_isInfoRunning)
                    {
                        _isInfoRunning = true;
                        try
                        {
                            var returnCode = GenerateDescription(out string info);
                            Info = string.Empty;
                            if (returnCode != BehaviorReturnCodes.Good)
                            {
                                Info = $"**** {DateTime.Now.ToLongDateString()} Execution Result {returnCode.ToString()} **** \n\r\n\r";
                            }
                            Info += info;
                        }
                        catch { }
                        _isInfoRunning = false;
                    }
                    if (!_isDescriptionRunning)
                    {
                        _isDescriptionRunning = true;
                        try
                        {
                            var returnCode = GenerateDescription(out string description);
                            Description = string.Empty;
                            if (returnCode != BehaviorReturnCodes.Good)
                            {
                                Description = $"**** {DateTime.Now.ToLongDateString()} Execution Result {returnCode.ToString()} **** \n\r\n\r";
                            }
                            Description += description;
                        }
                        catch { }
                        _isDescriptionRunning = false;
                    }
                    if (!_isInsightRunning)
                    {
                        _isInsightRunning = true;
                        try
                        {
                            var returnCode = GenerateInsight(out string insight);
                            Insight = string.Empty;
                            if (returnCode != BehaviorReturnCodes.Good)
                            {
                                Insight = $"**** {DateTime.Now.ToLongDateString()} Execution Result {returnCode.ToString()} **** \n\r\n\r";
                            }
                            Insight += insight;
                        }
                        catch { }
                        _isInsightRunning = false;
                    }
                    if (!_isResolutionRunning)
                    {
                        _isResolutionRunning = true;
                        try
                        {
                            var returnCode = GenerateResolution(out string resolution);
                            Resolution = string.Empty;
                            if (returnCode != BehaviorReturnCodes.Good)
                            {
                                Resolution = $"**** {DateTime.Now.ToLongDateString()} Execution Result {returnCode.ToString()} **** \n\r\n\r";
                            }
                            Resolution += resolution;
                        }
                        catch { };
                        _isResolutionRunning = false;
                    }
                }
                catch { }
                _executing = false;
            }
        }

        protected void Execute(object? sender, EventArgs e)
        {
            //this function is dedicated for event call back
            _executeByTimer = false; 
            Execute();
        }
        protected virtual BehaviorReturnCodes ProcessTask(out List<BehaviorValue> behaviorValues)
        {
            behaviorValues = new();
            return BehaviorReturnCodes.NotImplemented;
        }
        protected virtual BehaviorReturnCodes ProcessAnalytics(out List<BehaviorValue> behaviorValues) 
        {
            behaviorValues = new();
            return BehaviorReturnCodes.NotImplemented;
        }
        protected virtual BehaviorReturnCodes GenerateInfo(out string info)
        {
            info = "Not Implimented.";
            return BehaviorReturnCodes.NotImplemented;
        }
        protected virtual BehaviorReturnCodes GenerateDescription(out string description)
        {
            description = "Not Implimented.";
            return BehaviorReturnCodes.NotImplemented;
        }
        protected virtual BehaviorReturnCodes GenerateInsight(out string insight)
        {
            insight = "Not Implimented.";
            return BehaviorReturnCodes.NotImplemented;
        }

        protected virtual BehaviorReturnCodes GenerateResolution(out string resolution)
        {
            resolution = "Not Implimented.";
            return BehaviorReturnCodes.NotImplemented;
        }

        protected virtual void Load()    {      }

        protected virtual void Unload() { }

        #endregion default Functions

        


        public BrickEntity? AskAssociatedWith(params dynamic[] args) {  
            
            if (Parent == null) { return null; }

            return null; 
        }

        public BrickEntity? AskFedby(params dynamic[] args)
        {
            if (Parent == null) { return null; }

            return null;
        }

        public BrickEntity? AskMeterBy(params dynamic[] args)
        {
            if (Parent == null) { return null; }

            return null;
        }

        public BrickEntity? AskPartOf(params dynamic[] args)
        {
            if (Parent == null) { return null; }

            return null;
        }

        public BrickEntity? AskPointOfParent(string type, params dynamic[] args)
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
