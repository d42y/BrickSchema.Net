using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BrickSchema.Net.Classes.Equipments.HVACType.Chillers;
using BrickSchema.Net.Relationships;

namespace BrickSchema.Net.Classes.Equipments.HVACType
{
    public class Chiller : HVAC
    {
        public List<ChillerLoadCOP> DesignLoadCOP { get; set; } = new List<ChillerLoadCOP>();

        new public static string About
        {
            get
            {
                return "A chiller is a machine that removes heat from a liquid via a vapor-compression or absorption refrigeration cycle. This cooled liquid, usually water or a mix of water and anti-freeze, is then circulated through pipes to provide cooling in commercial, industrial, or institutional facilities." +
                        "\r\n\r\nChillers are an integral part of HVAC (Heating, Ventilation, and Air Conditioning) systems and are widely used for cooling purposes in applications such as air conditioning for large buildings, cooling manufacturing and industrial processes, and cooling medical and scientific equipment." +
                        "\r\n\r\nHere are the main components of a typical chiller:" +
                        "\r\n\r\n1. **Evaporator**: The evaporator is where the heat exchange happens. The liquid to be chilled flows over the evaporator tube bundle. As it does so, heat is transferred from the liquid to the refrigerant in the evaporator, causing the refrigerant to boil and turn into a low-temperature vapor." +
                        "\r\n\r\n2. **Compressor**: The compressor takes in the low-temperature refrigerant vapor from the evaporator, then compresses it, raising its pressure and temperature to create a high-temperature vapor." +
                        "\r\n\r\n3. **Condenser**: The condenser then cools the high-temperature vapor from the compressor. As the refrigerant vapor cools, it condenses and returns to a liquid state. The heat absorbed by the refrigerant is expelled outside the system, often with the aid of cooling towers." +
                        "\r\n\r\n4. **Expansion Valve**: This is a pressure reducing device. When the high-pressure liquid refrigerant passes through the valve, its pressure drops, and it partly vaporizes into a low-temperature, low-pressure mixture of liquid and vapor. It then returns to the evaporator, and the cycle begins again." +
                        "\r\n\r\nThere are primarily two types of chillers: air-cooled and water-cooled." +
                        "\r\n\r\n**Air-Cooled Chillers**: These chillers use ambient air to remove the heat from the refrigerant in the condenser. They are commonly used in small to medium-sized applications. They are usually located outside of the building and don't require a cooling tower or a condenser water pump, making them simpler and less expensive to install and maintain." +
                        "\r\n\r\n**Water-Cooled Chillers**: These chillers use water from an external cooling tower to condense the refrigerant in the condenser. They are typically used for medium to large cooling loads, and particularly in situations where the heat they reject can be used for other purposes, such as heating or preheating. While they are usually more energy-efficient than air-cooled chillers, they are more complex and require more maintenance." +
                        "\r\n\r\nChoosing the right type of chiller depends on many factors, including the cooling capacity needed, the ambient conditions, the availability of water, and the overall operating costs.";
            }

        }

        public List<BrickEntity> GetCoolingValveEntities()
        {
            var entities = GetCoolingValveEntities(this); 
            return entities;
        }

        private List<BrickEntity> GetCoolingValveEntities(BrickEntity entity)
        {
            List<BrickEntity> entities = new List<BrickEntity>();
            var children = entity.OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.ParentId == this.Id))
            .ToList();
            foreach (var child in children)
            {
                if (child.Type?.Equals(typeof(CoolingValve).Name)??false)
                {
                    entities.Add(child);
                    var grandChildren = GetCoolingValveEntities(child);
                    if (grandChildren != null)
                    {
                        entities.AddRange(grandChildren.Except(entities));
                    }
                }
            }
            return entities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>(min, max, average)</returns>
        public (double, double, double) GetCoolingValueCommandPointValues()
        {
            double min = 0;
            double max = 0;
            double average = 0;
            double sum = 0;
            int count = 0;

            var coolingValves = GetCoolingValveEntities();
            foreach (var entity in coolingValves)
            {
                var points = entity.GetPointEntities();
                foreach (var point in points)
                {
                    if (point.Type?.Equals(typeof(CoolingValve).Name) ?? false)
                    {
                        if (point.Value.HasValue)
                        {
                            if (point.Value < min) min = point.Value ?? min;
                            else if (point.Value > max) max = point.Value ?? max;

                            sum += point.Value ?? 0.0;
                            count++;
                        }
                    }
                }
            }
            average = sum / count;
            return (min, max, average);
        }


    }

    public class AbsorptionChiller : Chiller
    {

        new public static string About
        {
            get
            {
                return "A chiller is a machine that removes heat from a liquid via a vapor-compression or absorption refrigeration cycle. This cooled liquid, usually water or a mix of water and anti-freeze, is then circulated through pipes to provide cooling in commercial, industrial, or institutional facilities." +
                    "\r\n\r\nChillers are an integral part of HVAC (Heating, Ventilation, and Air Conditioning) systems and are widely used for cooling purposes in applications such as air conditioning for large buildings, cooling manufacturing and industrial processes, and cooling medical and scientific equipment." +
                    "\r\n\r\nAn absorption chiller is a type of chiller that uses a heat source to drive the refrigeration cycle instead of mechanical energy. While conventional chillers use an electrically powered compressor to circulate the refrigerant and remove heat, absorption chillers use a heat source like natural gas, steam, hot water, or solar-heated water to generate a cooling effect. " +
                    "\r\n\r\nThe key components of an absorption chiller are the evaporator, absorber, generator, and condenser, and its operation involves a cycle of evaporation and absorption. Here's how it typically works:" +
                    "\r\n\r\n1. **Evaporator**: The process starts in the evaporator, where a refrigerant (usually water) starts to evaporate at a low pressure to absorb heat from the chiller's surroundings (often the air or water in a building's HVAC system). This cools the surroundings and produces refrigerant vapor." +
                    "\r\n\r\n2. **Absorber**: The refrigerant vapor then enters the absorber. Here, it is absorbed by a solution (usually a lithium bromide solution), which creates a strong solution of refrigerant. The heat generated in this absorption process is usually removed by a cooling water loop." +
                    "\r\n\r\n3. **Generator**: The strong solution from the absorber is then pumped into the generator. Here, a heat source (such as natural gas, steam, or hot water) is used to boil off the refrigerant vapor from the strong solution. This creates a weak solution that returns to the absorber and a refrigerant vapor that moves on to the condenser." +
                    "\r\n\r\n4. **Condenser**: The refrigerant vapor from the generator enters the condenser, where it releases its heat and condenses back into a liquid. This heat is also usually removed by a cooling water loop. The liquid refrigerant then flows back to the evaporator to start the cycle again." +
                    "\r\n\r\nOne of the main advantages of absorption chillers is that they can use waste heat or other thermal energy sources that would otherwise be lost, which can make them a more energy-efficient choice in certain applications. They are also quiet and have fewer moving parts, which can mean less maintenance and longer equipment life." +
                    "\r\n\r\nHowever, they are typically more expensive to install and may be less energy-efficient than electric chillers if the thermal energy source is not readily available or if electricity prices are low. They're commonly used in large commercial or industrial installations where waste heat is readily available or there is a need to reduce electricity demand.";
            }
        }
    }
    public class CentrifugalChiller : Chiller
    {

        new public static string About
        {
            get
            {
                return "A chiller is a machine that removes heat from a liquid via a vapor-compression or absorption refrigeration cycle. This cooled liquid, usually water or a mix of water and anti-freeze, is then circulated through pipes to provide cooling in commercial, industrial, or institutional facilities." +
                    "\r\n\r\nChillers are an integral part of HVAC (Heating, Ventilation, and Air Conditioning) systems and are widely used for cooling purposes in applications such as air conditioning for large buildings, cooling manufacturing and industrial processes, and cooling medical and scientific equipment." +
                    "\r\n\r\nA centrifugal chiller is a type of chiller that uses the centrifugal force from a rotating impeller to compress refrigerant and provide cooling. They are commonly used in large commercial or industrial settings due to their high cooling capacities." +
                    "\r\n\r\nHere's a look at the key components and operation of a centrifugal chiller:" +
                    "\r\n\r\n1. **Evaporator**: The process starts in the evaporator, where low-pressure refrigerant absorbs heat from the chilled water circuit and boils, becoming a low-pressure gas." +
                    "\r\n\r\n2. **Compressor**: This gas then enters the centrifugal compressor. The compressor features an impeller, which is a disk with radial blades. As the impeller rotates, it draws the refrigerant gas in from the center and forces it out at the edges. This action increases the velocity of the refrigerant gas. The high-speed gas is then slowed down, which converts the kinetic energy into pressure, creating a high-pressure gas." +
                    "\r\n\r\n3. **Condenser**: This high-pressure gas then enters the condenser, where it releases its heat to the cooling water circuit and condenses into a high-pressure liquid." +
                    "\r\n\r\n4. **Expansion Device**: The high-pressure liquid refrigerant then passes through an expansion device, which reduces its pressure, resulting in a low-pressure, low-temperature refrigerant. This refrigerant then returns to the evaporator, and the cycle begins again." +
                    "\r\n\r\nThe key distinguishing feature of a centrifugal chiller is the centrifugal compressor, which is different from the reciprocating, rotary, or scroll compressors used in smaller chillers. The centrifugal compressor can handle large volumes of refrigerant, which is why centrifugal chillers are often used for large cooling loads." +
                    "\r\n\r\nCentrifugal chillers can offer high energy efficiency, particularly at full load, but their efficiency can drop off at part-load conditions. Many modern centrifugal chillers feature variable-speed drives and other advanced features to improve their part-load efficiency." +
                    "\r\n\r\nOne of the main benefits of centrifugal chillers is their efficiency at large capacities, especially in applications with a high cooling demand and relatively constant load. They also tend to be quieter and have fewer moving parts than reciprocating chillers, which can reduce maintenance needs. However, they can be more complex to design and manufacture, which can make them more expensive to purchase.";

            }
        }
    }

}
