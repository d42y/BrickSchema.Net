using BrickSchema.Net.Classes.Collection.Loop;
using BrickSchema.Net.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class TerminalUnit : HVAC
    {
        new public static string About
        {
            get
            {
                return "A terminal unit, also known as a terminal box or VAV box (Variable Air Volume box), is a critical component in heating, ventilation, and air conditioning (HVAC) systems, especially in VAV (Variable Air Volume) systems." +
                    "\r\n\r\nIn a HVAC system, the terminal unit is typically situated within the conditioned space of a building (often above the ceiling) and connected to both the ductwork distributing conditioned air and to the space it serves. It controls the volume of conditioned air (heated or cooled) delivered into the individual zones or rooms based on the demand." +
                    "\r\n\r\nTerminal units come in different types and configurations, each with its specific characteristics:" +
                    "\r\n\r\n1. **Single-Duct Terminal Units:** The most basic type of terminal unit is the single-duct terminal unit. This consists of a casing housing a damper and a control mechanism. The control mechanism adjusts the damper position based on the demand signal from a thermostat located in the zone the terminal unit serves. This type of unit is used in cooling-only applications or in conjunction with a separate heating system." +
                    "\r\n\r\n2. **Reheat Terminal Units:** These terminal units include a heating coil in addition to the components of a single-duct terminal unit. When the thermostat signals a need for heat, the control mechanism adjusts the damper to reduce the amount of cool air entering the zone and activates the heating coil to reheat the air to the desired temperature. The heating source could be hot water, steam, or electric." +
                    "\r\n\r\n3. **Fan-Powered Terminal Units:** These units include a small fan that operates when the damper is nearly closed (usually under low cooling or heating demand) to draw air from the plenum space, ensuring minimum airflow into the zone. Fan-powered terminal units can be either series-flow, where the fan runs continuously and mixes plenum and primary air together, or parallel-flow (also known as induction), where the fan operates only when the primary air volume is not sufficient, and the fan air is mixed with the cooled or heated air at the outlet of the terminal unit." +
                    "\r\n\r\n4. **Dual-Duct Terminal Units:** These terminal units have two duct connections, one for cooled air and one for heated air. Dampers in each duct are adjusted based on the thermostat signal to mix the cold and hot air to achieve the desired temperature. This provides quick response to temperature changes but can be less energy efficient due to the need to continuously condition two airstreams." +
                    "\r\n\r\nThe terminal units in a VAV system are typically controlled by a Building Management System (BMS), which allows for efficient centralized control and monitoring of the HVAC system. This setup allows the BMS to respond to changes in occupancy, outdoor temperature, and other factors to optimize comfort and energy efficiency." +
                    "\r\n\r\nThe type and configuration of the terminal units selected for a building depend on the specific requirements of the building, such as the range of heating and cooling loads, the presence of a central heating system, and the need for individual zone control. Understanding the different types of terminal units and their operation is essential for designing effective and efficient HVAC systems.";
            }
        }
    }


}
