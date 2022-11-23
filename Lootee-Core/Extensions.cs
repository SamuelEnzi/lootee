using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lootee_Core
{
    internal static class Extensions
    {
        public static bool Asset<T>(this T value, Predicate<T> assertion) =>
            assertion(value);
    }
}
