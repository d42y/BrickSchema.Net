using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType.TerminalUnits
{
    public class CAV : TerminalUnit
    {
        new public static string About
        {
            get
            {
                return "A Constant Air Volume (CAV) system, as the name suggests, is a type of heating, ventilation, and air conditioning (HVAC) system that supplies a constant volume of air while varying the temperature of the supplied air to meet heating or cooling needs. This is contrasted with a Variable Air Volume (VAV) system, which maintains a constant temperature but varies the volume of air to meet heating or cooling needs." +
                    "\r\n\r\nIn a CAV system, the volume of air is kept constant through the use of a fan that operates at a constant speed. The temperature of the air is then adjusted based on the heating or cooling requirements of the building. This adjustment is done either directly at the air handling unit, where the air is cooled or heated, or at the terminal units, where additional heating elements can be located." +
                    "\r\n\r\nThere are two primary types of CAV systems: single-zone systems and multi-zone systems." +
                    "\r\n\r\n1. **Single-Zone CAV Systems:** In these systems, the same amount of air is distributed throughout the entire building or zone at the same temperature. These systems are typically used in smaller, single-zone buildings where the heating and cooling loads are relatively uniform." +
                    "\r\n\r\n2. **Multi-Zone CAV Systems:** These systems have multiple zones, each with its own thermostat. The air handling unit produces a supply of air that can be heated or cooled. This air is then mixed in different proportions to meet the heating or cooling needs of each zone. " +
                    "\r\n\r\nWhile CAV systems can be simpler and less costly to install and maintain compared to VAV systems, they may not provide the same level of comfort and efficiency in buildings with highly variable or localized heating and cooling loads. This is because CAV systems can only supply one temperature of air at a time, which may not be ideal for all areas of the building." +
                    "\r\n\r\nFurthermore, because the volume of air is always constant, these systems can potentially waste energy when full heating or cooling is not needed. However, with the advent of variable frequency drives, it is possible to alter the speed of the supply fan in response to the overall demand for heating or cooling, which can help improve the energy efficiency of these systems." +
                    "\r\n\r\nIn sum, CAV systems can be a suitable choice for many applications, particularly in buildings with consistent and uniform thermal loads, but the specific needs and characteristics of the building should always be considered when selecting an HVAC system.";
            }

        }
    }

    public class ConstantAirVolumeBox : CAV { }

}
