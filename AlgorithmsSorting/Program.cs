using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/Thaceu/Desktop/Uni/Coding/AlgorithmsSorting/unsorted_numbers.csv";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();

            List<int> nums = fileLines.ConvertAll(line => Convert.ToInt32(line));

            ShellSort(ref nums);
            InsertionSort(ref nums);
            foreach (int num in nums) Console.WriteLine(num);

            BinarySearch(nums, 999912);
            LinearSearch(nums, 999912);
            Console.ReadKey();
            Console.WriteLine(LinearSearch(nums, 999912));
            Console.WriteLine(BinarySearch(nums, 999912));

        }
        // Shell Sortion
        static void ShellSort(ref List<int> nums)
        {
            for (int gap = nums.Count - 1; gap > 0; gap--)
            for (int i = 0; nums.Count > i + gap; i++)
            if (nums[i] > nums[i + gap])
                {
                    int temp = nums[i + gap];
                    nums[i + gap] = nums[i];
                    nums[i] = temp;
                }
        }

         //Insertion Sorting
        static void InsertionSort(ref List<int> nums)
        {
            for (int i = 1; nums.Count > i; i++)
            {
                int num = nums[i];
                int j = i;

                while (j > 0 && nums[j - 1] > num)
                    nums[j] = nums[--j];

                nums[j] = num;
            }
        }

        // Binary Search 
        public static int? BinarySearch(List<int> nums, int num)
        {
            int low = 0;
            int mid;
            int high = nums.Count - 1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (nums[mid] > num)
                {
                    high = mid - 1;
                }
                else if (nums[mid] < num)
                {
                    low = mid + 1;
                }
                else if (nums[mid] == num)
                {
                    return mid;
                }
            }
            return null;
        }

        // Linear Search 
         public static int? LinearSearch(List<int> nums, int num)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == num)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
