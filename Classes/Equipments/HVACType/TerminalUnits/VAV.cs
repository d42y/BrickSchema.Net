using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType.TerminalUnits
{
    public class VAV : TerminalUnit
    {
        new public static string About
        {
            get
            {
                return "A Variable Air Volume (VAV) system is a type of heating, ventilation, and air conditioning (HVAC) system designed to control temperatures in buildings by varying the amount of conditioned air delivered to different areas. In a VAV system, the volume of air can be changed in response to heating and cooling demands, while maintaining a constant temperature. " +
                    "\r\n\r\nIn addition to the basic principles of operation, there are various additional features and design options that can further enhance the effectiveness of a VAV system, such as reheat, return air options, and advanced controls." +
                    "\r\n\r\n**Reheat:** " +
                    "\r\n\r\nThe reheat function is often used in VAV systems to maintain comfort and adequate airflow in situations where the cooling load in a particular zone decreases. As the air volume to a zone decreases, there could be a risk of overcooling the space. To prevent this, the air can be reheated after cooling and before it is distributed to each zone. " +
                    "\r\n\r\nThe reheat process can be carried out in different ways. The most common types are electric reheat, hot water reheat, and steam reheat. Each type has its advantages and disadvantages, with the choice between them generally based on the specific requirements of the building and the available utilities." +
                    "\r\n\r\nWhile reheat systems can help improve occupant comfort by providing better temperature control, they can decrease the energy efficiency of the VAV system because they require additional energy to reheat the cooled air. For this reason, reheat should be used judiciously and is often controlled by building automation systems to minimize energy use." +
                    "\r\n\r\n**Return Air Options:**" +
                    "\r\n\r\nThere are typically two types of return air systems used in conjunction with VAV systems - ducted return and plenum return." +
                    "\r\n\r\n1. **Ducted Return:** In a ducted return system, return air is collected from each space through dedicated return air ducts and returned to the air handling unit." +
                    "\r\n\r\n2. **Plenum Return:** In a plenum return system, the space between the suspended ceiling and the structural ceiling, known as the plenum space, is used as a pathway for the return air. This can reduce the cost and complexity associated with return air duct systems, but requires that the plenum space is clean and free from contaminants." +
                    "\r\n\r\n**Advanced Controls:**" +
                    "\r\n\r\nAdvanced controls such as Direct Digital Controls (DDC) can be used to optimize the performance of VAV systems. These controls can provide precise control over airflow and temperature, enable zoning and scheduling, and can integrate with other building systems for improved energy efficiency." +
                    "\r\n\r\nAdditionally, controls like Variable Frequency Drives (VFDs) on the supply and return fans can modulate the fan speed, thereby saving energy when full airflow is not required. " +
                    "\r\n\r\n**Other Options:**" +
                    "\r\n\r\n1. **VAV with Terminal Heat:** In colder climates or for buildings with significant heating needs, a heating coil can be added at the terminal units. This can provide heating at the zone level, improving comfort and reducing the need to reheat air at the central unit." +
                    "\r\n\r\n2. **Fan-Powered VAV Boxes:** These boxes contain a small fan that can draw in air from the plenum space when the primary air supply is reduced. This can help maintain adequate ventilation and comfort levels." +
                    "\r\n\r\n3. **Dual-Duct VAV Systems:** These systems have two ducts supplying air to each zone - one with cooled air and one with heated air. The proportion of air from each duct can be varied to achieve the desired temperature." +
                    "\r\n\r\nVAV systems, especially when equipped with advanced features and options, can provide an effective and flexible solution for the heating and cooling needs of a variety of buildings. They offer better energy efficiency than constant volume systems, while still ensuring high levels of occupant comfort.\r\n";
            }
        }
    }
    public class VariableAirVolumeBox : VAV { }
    public class RVAV : VAV { }
    public class VariableAirVolumeBoxWithReheat : RVAV { }

}
