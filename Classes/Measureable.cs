using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrickSchema.Net.Classes
{
    //Measureable
    public class Measurable : BrickClass 
    {
        
        public Measurable()
        {
            AddOrUpdateProperty(EntityProperties.PropertiesEnum.BrickClass, typeof(Measurable).Name);
        }
    }
}
    
