using BrickSchema.Net.Classes.Measureable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //Measureable
        public Quantity AddMeasurableQuantity(string? id = null) => AddEntity<Quantity>(id);
        public Substance AddMeasurableSubstance(string? id = null) => AddEntity<Substance>(id);
    }
}
