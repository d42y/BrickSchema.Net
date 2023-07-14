using BrickSchema.Net.Classes.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //point

        public Alarm AddPointAlarm(string? id = null) => AddEntity<Alarm>(id);
        public Command AddPointCommand(string? id = null) => AddEntity<Command>(id);
        public Parameter AddPointParameter(string? id = null) => AddEntity<Parameter>(id);
        public Sensor AddPointSensor(string? id = null) => AddEntity<Sensor>(id);
        public Setpoint AddPointSetpoint(string? id = null) => AddEntity<Setpoint>(id);
        public Status AddPointStatus(string? id = null) => AddEntity<Status>(id);
    }
}
