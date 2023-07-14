using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Devices
{
    public class Device : BrickClass
    {
        public string? Address { get; set; }
        public Device()
        {
            AddOrUpdateProperty(EntityProperties.PropertiesEnum.BrickClass, typeof(Device).Name);
        }
        
    }

    public class BACnetDevice : Device {
        public string? Protocol { get; set; }
    }
    public class ModbusDevice : Device { }
    public class  Server : Device { }
    public class Workstation : Device { }

}
