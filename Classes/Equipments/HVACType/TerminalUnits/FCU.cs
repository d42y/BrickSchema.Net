using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType.TerminalUnits
{
    public class FCU : TerminalUnit
    {

        new public static string About
        {
            get
            {
                return "A Fan Coil Unit (FCU) is a simple device consisting of a heating or cooling coil and a fan. It is part of an HVAC system and is used to control the temperature in the space where it is installed. It works by transferring heat between the air and a heating or cooling fluid (water or a refrigerant) that flows through the coil." +
                    "\r\n\r\nFCUs are versatile and come in many configurations. Here are the main components and their roles:" +
                    "\r\n\r\n1. **Fan:** The fan's role is to circulate air over the heating or cooling coil, and then distribute it into the room. The fan speed can often be adjusted to control the volume of air." +
                    "\r\n\r\n2. **Coil:** The coil is where the actual heating or cooling takes place. Hot or cold water or refrigerant flows through the coil, and as air passes over the coil, heat is exchanged." +
                    "\r\n\r\n3. **Filters:** FCUs usually include air filters to remove dust and particulates from the air before it is heated or cooled. This not only ensures cleaner air is delivered to the room but also protects the unit from potential damage." +
                    "\r\n\r\n4. **Controls:** These are used to set the desired temperature and to regulate the operation of the unit. Controls may be simple manual switches or thermostats, or they may be more complex digital or networked systems." +
                    "\r\n\r\nFCUs can be used for both heating and cooling, and the source of the heating or cooling can be a central plant, such as a boiler or chiller, or a local device like a condensing unit. Some FCUs also include electric heating elements for additional heating capacity." +
                    "\r\n\r\nThere are three common types of FCUs:" +
                    "\r\n\r\n1. **Two-Pipe FCU:** In this system, either heated or chilled water is available at any given time. This makes it suitable for situations where only heating or cooling is required during particular times of the year. However, it cannot provide heating in one area and cooling in another at the same time." +
                    "\r\n\r\n2. **Four-Pipe FCU:** This system has separate pipes for the heated and chilled water, allowing for heating and cooling to occur simultaneously in different areas. This is useful in larger buildings where different zones may have different temperature requirements." +
                    "\r\n\r\n3. **Direct Expansion (DX) FCU:** Instead of water, this type of FCU uses refrigerant from a condensing unit. The refrigerant evaporates in the FCU, cooling the air, and is then condensed back to a liquid in the condensing unit. " +
                    "\r\n\r\nFCUs are commonly used in commercial buildings, hotels, apartments, and condominiums, especially in individual rooms or zones. Their advantages include simplicity, ease of control, and the ability to provide heating and cooling in a compact unit. However, they may not be as energy efficient as some other systems, and they require regular maintenance to ensure they operate effectively.";
            }
        }
    }

    public class FanCoilUnit : FCU { }



}
