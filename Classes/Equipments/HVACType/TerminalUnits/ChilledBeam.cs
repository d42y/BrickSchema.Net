using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType.TerminalUnits
{
    public class ChilledBeam : TerminalUnit {
        new public static string About
        {
            get
            {
                return "A chilled beam is a type of convection HVAC system used in commercial and institutional buildings. The system is designed to heat or cool large spaces and is often preferred for its energy efficiency and lower operating costs. " +
                    "\r\n\r\nThere are two primary types of chilled beams: passive chilled beams and active chilled beams. " +
                    "\r\n\r\n1. **Passive Chilled Beams:** Also known as convective or natural chilled beams, these rely on the natural convection process to condition the space. They consist of a cooling coil that is housed in a metal casing suspended from the ceiling. As warm room air rises, it comes into contact with the chilled beam, is cooled, and then descends back into the room. This creates a continuous cycle of air movement. Passive chilled beams only provide cooling; they do not supply fresh air or offer heating." +
                    "\r\n\r\n2. **Active Chilled Beams:** These offer more capabilities than passive beams. In addition to a cooling coil, they have an air supply duct. Primary air (fresh air) is supplied by the central air handling unit (AHU) and is ducted into the beam. This air passes through nozzles, which create a pressure difference and induce room air to move across the heating or cooling coils and then mix with the primary air. The resulting conditioned air is then delivered into the space. Active beams can be used for both cooling and heating." +
                    "\r\n\r\nIn both types, heating or cooling is achieved by circulating chilled or heated water through the coils in the beam. The water is typically supplied by a central chiller or boiler." +
                    "\r\n\r\nChilled beam systems have several advantages:" +
                    "\r\n\r\n- **Energy Efficiency:** They use water as the primary means of heat transfer, which is more efficient than air, reducing energy use." +
                    "\r\n\r\n- **Noise Levels:** They operate quietly, making them suitable for environments that require low noise levels, like offices, hospitals, and libraries." +
                    "\r\n\r\n- **Air Quality:** In an active chilled beam system, the primary air supplied is typically treated and filtered, contributing to improved indoor air quality." +
                    "\r\n\r\n- **Space Saving:** They are compact and do not require much vertical space, which can lead to increased floor-to-floor heights or reduced building height." +
                    "\r\n\r\nDespite their advantages, chilled beams also have some considerations:" +
                    "\r\n\r\n- **Condensation:** If the chilled water temperature is not properly controlled, or if the space humidity is not properly managed, condensation can occur on the chilled beam, leading to potential water damage." +
                    "\r\n\r\n- **Installation Costs:** Chilled beam systems can have higher upfront costs compared to traditional HVAC systems due to their need for a dedicated water supply and return system." +
                    "\r\n\r\n- **Limitation on Cooling Capacity:** The cooling capacity of a chilled beam system is limited by the dew point temperature in the room to prevent condensation. This can limit their effectiveness in high-load applications." +
                    "\r\n\r\nChilled beams offer a solution for energy-efficient, quiet, and comfortable heating and cooling in a variety of commercial settings. As with all HVAC systems, they should be selected and designed considering the specific requirements and conditions of each project.";
            }
        }
    }

    
}
