using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingApplication
{
    class Sorter
    {
        public ISorting Strategy { get; set; }
        //private int[] Array { get; set; }

        public Sorter(ISorting strategy)
        {
            Strategy = strategy;
        }
        public void Sort(int[]  Array)
        {
            Strategy.Sort(Array);
        }

    }
}
