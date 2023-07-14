using BrickSchema.Net.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Classes
{
    //Equipment class
    public class Equipment : BrickClass
    {
        public Equipment() { }
        internal Equipment(BrickEntity entity):base(entity) { } //for internal use

        public override Equipment Clone()
        {
            var clone = new Equipment(base.Clone());
            return clone;
        }
    }
}
