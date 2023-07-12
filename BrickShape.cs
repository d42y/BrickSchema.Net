using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public class BrickShape : BrickEntity
    {
        public override BrickShape Clone()
        {
            var clone = (BrickShape)base.Clone();
            return clone;
        }
    }
}
