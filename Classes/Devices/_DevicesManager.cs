using BrickSchema.Net.Classes.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //Devices
        public BACnetDevice AddBACnetDevice(string? id = null) => AddEntity<BACnetDevice>(id);
        public ModbusDevice AddModbusDevice(string? id = null) => AddEntity<ModbusDevice>(id);
        public Workstation AddWorkstation(string? id = null) => AddEntity<Workstation>(id);
        public Server AddServer(string? id = null) => AddEntity<Server>(id);
    }
}
