using BrickSchema.Net.Classes.Points;


namespace BrickSchema.Net.Classes
{
    //Point class

    public class Point : BrickClass
    {
        

        public double? Value
        {
            get
            {
                return GetProperty<double>(EntityProperties.PropertiesEnum.Value);
            }
            private set
            {
                if (Value != value)
                {
                    AddOrUpdateProperty(EntityProperties.PropertiesEnum.Value, value);
                    NotifyValueChange();
                }
            }
        }
        public DateTime Timestamp
        {
            get
            {
                return GetProperty<DateTime>(EntityProperties.PropertiesEnum.Timestamp);
            }
            private set
            {
                AddOrUpdateProperty(EntityProperties.PropertiesEnum.Timestamp, value);
            }
        }
        public PointValueQuality Quality {
            get
            {
                return GetProperty<PointValueQuality>(EntityProperties.PropertiesEnum.ValueQuality);
            }
            private set
            {
                AddOrUpdateProperty(EntityProperties.PropertiesEnum.ValueQuality, value);
            }
        } 


        public void UpdateValue(double? value, DateTime timestamp, PointValueQuality valueQuality = PointValueQuality.Good)
        {
            Value = value;
            Timestamp = timestamp;
            Quality = valueQuality;
            
        }

        public Point ClonePoint()
        {
            var clone = (Point)Clone();
            clone.Value = Value??0.0;
            clone.Quality = Quality;
            clone.Timestamp = Timestamp;
            return clone;
        }
    }

    
}
