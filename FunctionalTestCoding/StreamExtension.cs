using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalTestCoding
{
    public static class StreamExtension 
    {
        public static R Using<T, R>(this T item, Func<T, R> func) where T : IDisposable
        {

            using (item)
                return func(item);
        }
    }
}