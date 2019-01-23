using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new int[] { 1, 20, 5, 6, 88, 256, 3 };
            ShowClosestCombination(arr1, 52);
            ShowClosestCombination(arr1, 300);

            var arr2 = new int[] { 99, 10, 5, 3, 8, 1 };
            ShowClosestCombination(arr2, 15);

            var arr3 = new int[] { 1, 256, 3, 87, 88 };
            ShowClosestCombination(arr3, 52);

            var arr4 = new int[] { 3 };
            ShowClosestCombination(arr4, 52);

            Console.WriteLine("Thank you! Press any key to close!");
            Console.ReadKey();
        }


        private static void ShowClosestCombination(int[] arr, int target)
        {
            string exampleText = $"Example - {String.Join(", ", arr)} - Target = {target}";
            string resultText;

            if (arr.Length < 2)
            {
                resultText = $"Result - Not possible to find 2 numbers";
            }
            else
            {
                int num1 = 0, num2 = 0;
                int? diff = null;

                var tmp = arr.OrderByDescending(x => x).ToArray();

                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    bool found = false;

                    for (int j = i + 1; j < tmp.Length; j++)
                    {
                        var currDiff = Math.Abs(target - (tmp[i] + tmp[j]));
                        if (diff.HasValue && currDiff >= diff)
                        {
                            if (tmp[i] > target)
                                continue;

                            found = true;
                            break;
                        }

                        num1 = tmp[i];
                        num2 = tmp[j];
                        diff = currDiff;
                    }

                    if (found)
                        break;
                }

                resultText = $"Result - {num1} + {num2}";
            }

            Console.WriteLine(exampleText);
            Console.WriteLine(resultText);
            Console.WriteLine("---------------------------------------");
        }

    }
}
