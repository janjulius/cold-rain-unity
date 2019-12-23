using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.extensions
{
    public static class ArrayExtensions
    {
        public static void SwapValues<T>(this T[] source, long index1, long index2)
        {
            T temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }
    }
}
