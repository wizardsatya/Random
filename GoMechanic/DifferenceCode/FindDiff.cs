using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    class FindDiff
    {
        public static bool FindTheDiff(int[] arr, int a)
        {
            int i = 0, j = 1;
            bool Exists = false;
            while (i < arr.Length - 1)
            {
                if (arr[j] - arr[i] > a)
                {
                    if (i != arr.Length - 1)
                    {
                        i++;
                        j = i + 1;
                        continue;
                    }
                    else
                    {

                        Exists = false;
                        break;
                    }
                }
                if (arr[j] - arr[i] == a)
                {
                    Exists = true;
                    break;
                }
                if (arr[j] - arr[i] < a)
                {
                    if (i == arr.Length - 2)
                    {
                        break;
                    }
                    j++;

                    continue;
                }
            }

            return Exists;
        }
    }
}
