using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travelingSalesman
{
    public static class Extensions
    {
        public static IEnumerable<string> GetCopy(this List<string> list)
        {
            string[] buffer = new string[list.Count];
            list.CopyTo(buffer);
            return buffer.ToList();
        }
    }
}
