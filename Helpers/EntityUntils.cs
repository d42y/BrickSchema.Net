using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.Helpers
{
    public static class EntityUntils
    {
        public static string GetTypeName<T>()
        {
            string tName = typeof(T).Name;
            if (tName.StartsWith("Nullable"))
            {
                Type nullableType = typeof(T?);
                Type? underlyingType = Nullable.GetUnderlyingType(nullableType);
                tName = underlyingType?.Name ?? "null";

            }
            return tName;
        }
    }
}
