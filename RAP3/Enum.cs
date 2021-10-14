using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP3
{
    public static class Enum
    {

        public static T ToEnum<T>(this string description)
        {
            return (T)System.Enum.Parse(typeof(T), description);
        }

    }
}
