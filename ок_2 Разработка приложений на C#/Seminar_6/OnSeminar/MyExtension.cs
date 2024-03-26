using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    public static class Extension
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Predicate<T> predicat)
        {
            foreach (var item in collection)
            {
                if (predicat(item))
                {
                    yield return item;
                }
            }
        }
    }
}
