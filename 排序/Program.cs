using System;

namespace 排序
{
    class Counts
    {
        public static int count1 = 0;
        public static int count2 = 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                array[i] = rand.Next(0, 100);
            }
            Console.WriteLine("排序前的数组：");
            foreach (var item in array)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("冒泡排序后的数组：");
            foreach (var item in Sort.PopSort(array))
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\n快速排序后的数组：");
            int[] arr = new int[array.Length];
            array.CopyTo(arr, 0);
            Sort.QuickSort(arr, 0, arr.Length - 1);
            foreach (var item in arr)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\n\n冒泡排序的比较次数：{0}\n快速排序的交换次数：{1}", Counts.count1, Counts.count2);
            Console.ReadLine();
        }
    }

    static class Sort
    {
        public static int[] PopSort(int[] array)
        {
            int[] arr = new int[array.Length];
            array.CopyTo(arr, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++) 
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        Counts.count1++;
                    }
                    else continue;
                }
            }
            return arr;
        }

        private static int sortUnit(int[] array, int low, int high)
        {
            int key = array[low];
            while (low < high)
            {
                while (array[high] >= key && high > low)
                {
                    --high;
                }
                array[low] = array[high];
                Counts.count2++;
                while (array[low] <= key && high > low)
                {
                    ++low;
                }
                array[high] = array[low];
                Counts.count2++;
            }
          array[low] = key;
            return high;
        }

        public static void QuickSort(int[] array, int low, int high)
        {        
            if (low >= high)
                return;
            int index = sortUnit(array, low, high);
            QuickSort(array, low, index - 1);
            QuickSort(array, index + 1, high);
        }
    }
}
