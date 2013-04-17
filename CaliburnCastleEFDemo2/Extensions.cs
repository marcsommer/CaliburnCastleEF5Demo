using System;
using System.Collections.Generic;

namespace CaliburnCastleEFDemo2
{
   public static class Extensions
   {
      public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
      {
         foreach (T element in source)
         {
            action(element);
         }
      }
   }
}