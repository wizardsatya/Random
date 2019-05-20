using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    class FindUniversalStrings
    {
        public static int FindUniversalString(string NBinStr)
        {
            string FirstString, SecondString, ThirdString = null;
            int IndexOfZero = NBinStr.IndexOf('0');
            if (IndexOfZero > -1)
            {
                FirstString = NBinStr.Substring(0, IndexOfZero);
                int IndexOfOne = NBinStr.IndexOf('1', IndexOfZero);
                if (IndexOfOne > -1)
                {
                    SecondString = NBinStr.Substring(IndexOfZero, IndexOfOne - IndexOfZero);
                    int IndexOfNextZero = NBinStr.IndexOf('0', IndexOfOne);
                    if (IndexOfNextZero > -1)
                    {
                        ThirdString = NBinStr.Substring(IndexOfOne, IndexOfNextZero - IndexOfOne);
                    }
                    else
                    {
                        ThirdString = NBinStr.Substring(IndexOfOne, NBinStr.Length - IndexOfOne);
                    }
                }
                else
                {
                    SecondString = NBinStr.Substring(IndexOfZero, NBinStr.Length - IndexOfZero);
                    ThirdString = "";
                }
            }
            else
            {
                FirstString = NBinStr;
                SecondString = "";
                ThirdString = "";
            }


            int count = FirstString.Length + SecondString.Length + ThirdString.Length;
            Console.WriteLine(NBinStr + "  :   " + FirstString + SecondString + ThirdString + " And count is " + count);
            string LeftString = NBinStr.Remove(0, FirstString.Length + SecondString.Length);
            if (LeftString.Length > 0)
            {
                int Newcount = FindUniversalString(LeftString.TrimStart('0'));
                if (Newcount > count)
                {
                    count = Newcount;
                }
            }

            return count;
        }
    }
}
