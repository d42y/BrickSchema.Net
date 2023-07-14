using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes
{
    public class Tenant : BrickClass
    {
        public Tenant() 
        {
            AddOrUpdateProperty(EntityProperties.PropertiesEnum.BrickClass, typeof(Tenant).Name);
        }
    }
}
