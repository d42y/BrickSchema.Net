using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class AHU : HVAC {
    
        new public static string About
        {
            get
            {
                return "AHU stands for Air Handling Unit, and it is a key part of many HVAC (Heating, Ventilating, and Air Conditioning) systems. The AHU is a large metal box containing various components designed to control and circulate air as part of a heating, ventilating, and air-conditioning (HVAC) system." +
                    "\r\n\r\nThe primary function of the AHU is to take in outside air, condition it, and distribute it around a building. It can also recirculate and condition air within a building. " +
                    "\r\n\r\nHere are some of the main components typically found in an AHU:" +
                    "\r\n\r\n1. **Fans**: These are the primary component of an AHU and are used to draw in and distribute air." +
                    "\r\n\r\n2. **Filters**: The AHU uses filters to remove dust, allergens, and other particles from the air. This is important for maintaining air quality and for the health of those in the building." +
                    "\r\n\r\n3. **Heating and cooling coils**: These are used to adjust the temperature of the air. The heating coil may use hot water or electric resistance heaters. The cooling coil is usually part of the building's refrigeration system and uses chilled water or refrigerant." +
                    "\r\n\r\n4. **Humidifier/Dehumidifier**: This is used to control the humidity of the air. It can add moisture to dry air or remove moisture from damp air." +
                    "\r\n\r\n5. **Mixing Box**: This is where the return air and fresh air are combined and then sent to the heating or cooling coils." +
                    "\r\n\r\n6. **Dampers**: These control the flow of air inside the unit." +
                    "\r\n\r\n7. **Sound Attenuators**: These help to reduce the noise produced by the AHU." +
                    "\r\n\r\nThe specific configuration and components of an AHU can vary greatly depending on the requirements of the building, the local climate, and the quality of the outside air." +
                    "\r\n\r\nIn terms of energy usage, the AHU can be one of the biggest consumers in a building, so modern units often have features designed to reduce energy use, such as heat recovery systems and variable speed drives.";
            }
        }
    }
    public class AirHandlerUnit : AHU { }
    public class AirHandlingUnit : AHU { }
}
