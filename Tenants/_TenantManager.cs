using BrickSchema.Net.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //tenant
        public Tenant AddTenant(string? id = null) => AddEntity<Tenant>(id);
    }
}
