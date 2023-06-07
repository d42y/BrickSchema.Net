using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Locations
{
    public class Building : Location { }

    public class Floor : Location { }
    public class OutdoorArea : Location { }
    public class Outside : Location { }
    public class Region : Location { }
    public class Site : Location { }
    public class Space : Location { }
    public class CommonSpace : Space { }
    public class Entrance : Space { }
    public class GateHouse : Space { }
    public class MediaHotDesk : Space { }
    public class Parking : Space { }
    public class Room : Space { }
    public class TicketingBooth : Space { }
    public class Tunnel : Space { }
    public class VerticalSpace : Space { }
    public class WaterTank : Space { }
    public class Storey : Location { }
    public class Wing : Location { }
    public class Zone : Location { }
}
