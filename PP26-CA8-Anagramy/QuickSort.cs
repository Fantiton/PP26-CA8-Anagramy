using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP26_CA8_Anagramy
{
    public class QuickSort
    {
        public void sort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }

        private void quicksort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = partition(array, low, high);

                quicksort(array, low, pivotIndex - 1);
                quicksort(array, pivotIndex + 1, high);
            }
        }

        private int partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    swap(array, i, j);
                }
            }

            swap(array, i + 1, high);
            return i + 1;
        }

        private void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
