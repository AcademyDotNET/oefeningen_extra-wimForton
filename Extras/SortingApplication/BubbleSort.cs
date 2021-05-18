using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingApplication
{
    class BubbleSort : SortersParentClass, ISorting
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("BubbleSort");
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        swapped = true;
                        Swap(i, i + 1, array);
                    }
                }
            }
        }
    }
}
