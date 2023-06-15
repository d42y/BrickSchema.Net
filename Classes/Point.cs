using BrickSchema.Net.Classes.Points;
using BrickSchema.Net.Relationships;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes
{
    //Point class

    public class Point : BrickClass
    {
        

        public double? Value { get; private set; } = null;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public PointValueQuality Quality { get; set;  } = PointValueQuality.Unknown;


        public void UpdateValue(double? value, DateTime timestamp, PointValueQuality valueQuality = PointValueQuality.Good)
        {
            Value = value;
            Timestamp = timestamp;
            Quality = valueQuality;
            NotifyValueChange();
        }

        public Point ClonePoint()
        {
            var clone = (Point)CloneIdentity();
            clone.Value = Value??0.0;
            clone.Quality = Quality;
            clone.Timestamp = Timestamp;
            return clone;
        }
    }

    
}
