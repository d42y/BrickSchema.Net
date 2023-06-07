using BrickSchema.Net.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class ColdDeck : HVAC {


        new public static string About { get
            {
                return "In the context of HVAC systems, a \"cold deck\" refers to a part of a dual duct air conditioning system, also known as a \"reheat\" system. " +
                    "\r\n\r\nA dual duct system is typically designed with two parallel ducts: one referred to as the \"hot deck,\" and the other as the \"cold deck.\" Each duct delivers air at a different temperature. The \"cold deck\" supplies cooled air, usually at a constant temperature, while the \"hot deck\" supplies heated air. " +
                    "\r\n\r\nThe main advantage of this type of system is that it allows for a high degree of control over the temperature in different zones or areas within a building. By mixing air from the hot and cold decks in varying proportions, the system can precisely regulate the temperature in each zone." +
                    "\r\n\r\nHere's how it typically works:" +
                    "\r\n\r\n1. **Cooling**: The cold deck is supplied with air that has been cooled by passing over the cooling coils in an air handling unit. This cooled air is then distributed through the cold deck ductwork to various parts of the building." +
                    "\r\n\r\n2. **Heating**: Simultaneously, the hot deck is supplied with air that has been heated by passing over the heating coils. This hot air is then distributed through the hot deck ductwork." +
                    "\r\n\r\n3. **Mixing**: At each zone of the building, air from the cold and hot decks is mixed in a terminal unit (also known as a mixing box) to achieve the desired temperature. The proportions of hot and cold air can be adjusted for each zone based on the thermostat settings." +
                    "\r\n\r\nThe dual duct system is often used in larger buildings with many zones, such as commercial buildings or hospitals, where there can be a significant variation in the heating or cooling requirements in different parts of the building. However, they can be more expensive to install and operate than other types of systems, due to the need for two sets of ductwork and the energy used to heat or cool air to a constant temperature, regardless of the outside weather conditions.";
            } }
    
    }
}
