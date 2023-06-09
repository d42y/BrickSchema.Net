﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class CRAC : HVAC {

        new public static string About
        {
            get
            {
                return "Computer Room Air Conditioning (CRAC). It is a type of air conditioning system specifically designed to maintain the temperature, air distribution, and humidity in network rooms or data centers. Proper environmental control is crucial in such spaces because the electronic equipment, particularly servers and network devices, generate a significant amount of heat and are sensitive to variations in temperature and humidity." +
                    "\r\n\r\nHere are the main functions of a CRAC unit:" +
                    "\r\n\r\n1. **Temperature Control**: Maintaining an appropriate temperature is crucial for the reliable operation of IT equipment. Overheating can lead to hardware failure, resulting in system downtime. CRAC units help control the temperature by removing the heat generated by the IT equipment and expelling it outside of the space." +
                    "\r\n\r\n2. **Humidity Control**: CRAC units also regulate humidity. Too much humidity can cause condensation and result in corrosion or electrical shorts. Conversely, too little humidity can cause static electricity buildup, which can also damage IT equipment. CRAC units add or remove moisture as needed to maintain an appropriate humidity level." +
                    "\r\n\r\n3. **Air Distribution**: Proper air distribution is important to prevent hotspots where heat can build up and cause equipment to overheat. CRAC units use fans to circulate conditioned air and keep the temperature consistent throughout the space." +
                    "\r\n\r\nCRAC units can operate in two modes: cooling mode and dehumidifying mode, based on the requirements of the data center. They usually have a direct expansion (DX) system where a refrigerant is evaporated in an air-stream, and the cool air is distributed throughout the data center. " +
                    "\r\n\r\nA CRAC unit is often part of a larger HVAC solution, working in conjunction with other cooling devices such as in-row coolers, rear-door heat exchangers, or chillers. " +
                    "\r\n\r\nIt's worth noting that in the data center industry, there's another similar term, CRAH, which stands for Computer Room Air Handler. CRAH units are a bit different from CRAC units as they typically use chilled water to remove heat, instead of refrigerants. Both CRAC and CRAH systems have their own advantages and are used based on specific requirements of the data center." +
                    "\r\n\r\nSelecting and sizing CRAC units requires careful planning, taking into account the heat load of the equipment, the size and layout of the space, and the local climate, among other factors.";
            }
        }
    
    }
    public class ComputerRoomAirConditioning : CRAC {
    
    }
}
