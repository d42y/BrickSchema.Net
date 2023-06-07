using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class AirPlenum : HVAC {

        new public static string About
        {
            get
            {
                return "An air plenum is an important component in heating, ventilation, and air conditioning (HVAC) systems. The term \"plenum\" generally refers to any enclosed portion of the HVAC system that functions as a channel for the distribution or collection of air. Essentially, it's a chamber where air or another fluid is collected before being redistributed to different spaces or locations." +
                    "\r\n\r\nIn the HVAC context, there are typically two main types of air plenums:" +
                    "\r\n\r\n1. **Supply Plenum**: This plenum is attached to the HVAC unit's output, and it directs air into the ductwork system for distribution throughout a building. The supply plenum starts at the HVAC unit and typically has a large rectangular opening that becomes smaller as it connects to the individual supply ducts. This helps to maintain proper airflow." +
                    "\r\n\r\n2. **Return Plenum**: This plenum is where the air returns to the HVAC unit. It collects used air from the return ductwork, and this air is either exhausted out of the system or re-heated or re-cooled to maintain the desired temperature in the building." +
                    "\r\n\r\nOne of the most important aspects of air plenum design is ensuring that the air pressure is correct. If the pressure is too high or too low, it can affect the efficiency of the HVAC system and the comfort of the building's occupants. " +
                    "\r\n\r\nThe design of the plenums and their connection to the ductwork can also have a significant effect on noise levels. Poor design can lead to noise from the HVAC unit being transmitted through the ductwork to the occupied spaces." +
                    "\r\n\r\nIn some cases, the space above a drop ceiling or below a raised floor is used as an air return plenum. In these cases, it's particularly important that the space is sealed and insulated properly, and that only materials safe for this use are installed in the plenum space." +
                    "\r\n\r\nAnother term you might encounter is \"plenum-rated\" or \"plenum-safe.\" This is often used to describe cables or other materials that have been designed and tested to meet specific safety standards related to fire resistance and smoke production, making them safe for use in plenum spaces.";
            }
        }
    }
}
