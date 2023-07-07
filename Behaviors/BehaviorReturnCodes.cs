using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Behaviors
{
    public enum BehaviorReturnCodes
    {
        NotImplemented = -1,
        Good = 0,
        Skip = 1,
        HasWarning = 10,
        HasError = 50,
        HasException = 100
    }
}
