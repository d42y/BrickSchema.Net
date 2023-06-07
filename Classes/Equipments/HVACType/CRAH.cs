using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class CRAH : HVAC { 
    
        new public static string About
        {
            get
            {
                return "Computer Room Air Handler (CRAH). It's a type of device used to monitor and maintain the temperature, air distribution, and humidity in network rooms, data centers, or other environments that house IT equipment." +
                    "\r\n\r\nWhile they perform similar functions to Computer Room Air Conditioning (CRAC) units, there's a significant difference in how they cool the air:" +
                    "\r\n\r\n**CRAC units** typically use direct expansion (DX) cooling. They contain a refrigeration system that cools air directly by evaporating a refrigerant. " +
                    "\r\n\r\n**CRAH units**, on the other hand, use chilled water as the cooling medium. A separate chiller cools the water, which then circulates through a coil in the CRAH unit. Air from the room is passed over the chilled water coil, thereby reducing its temperature." +
                    "\r\n\r\nHere are the main functions of a CRAH unit:" +
                    "\r\n\r\n1. **Temperature Control**: CRAH units help maintain a consistent temperature in the data center by drawing warm air from the room, passing it over the cooling coils, and then returning the cooled air back into the room. This is vital because IT equipment, like servers, can generate a significant amount of heat, which can lead to hardware failure if not properly managed." +
                    "\r\n\r\n2. **Humidity Control**: CRAH units also help regulate humidity levels in the data center. Too much humidity can lead to condensation and corrosion, while too little can cause problems with static electricity. Many CRAH units are equipped with humidifiers and dehumidifiers to maintain an optimal humidity level." +
                    "\r\n\r\n3. **Air Distribution**: Good air circulation is important to avoid hotspots and ensure that all equipment is adequately cooled. CRAH units use fans to distribute cooled air and maintain a consistent temperature throughout the room." +
                    "\r\n\r\nA key advantage of CRAH units is their energy efficiency. They can be more efficient than CRAC units, particularly in larger installations, because they leverage the high specific heat capacity of water. This allows a CRAH system to transport the same amount of heat using less energy compared to an air-based system." +
                    "\r\n\r\nHowever, CRAH units do require a source of chilled water, usually provided by a separate chiller, and the necessary plumbing infrastructure. This can make them more complex and potentially more expensive to install than CRAC units, but the operating costs can be lower, particularly for larger installations." +
                    "\r\n\r\nSelecting between CRAC and CRAH, and sizing these units appropriately, is a critical part of data center design. The choice will depend on many factors, including the heat load of the equipment, the size and layout of the room, the local climate, and the availability of resources such as water and electricity.";
            }
        }
    
    }
    public class ComputerRoomAirHandler : CRAH { }
}
