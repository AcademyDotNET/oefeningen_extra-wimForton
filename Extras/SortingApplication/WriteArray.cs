using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingApplication
{
    static class WriteArray
    {
        public static void Write(int[] inArray)
        {
            string fillMeUp = "";
            foreach (var item in inArray)
            {
                fillMeUp += Convert.ToString(item) + " ";
            }
            Console.WriteLine(fillMeUp);
        }
    }
}
