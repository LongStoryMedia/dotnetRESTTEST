using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringAnalysisREST
{
    public static class StringAnalyzer
    {
        public static List<Dictionary<string, object>> GetStringMetaData(this string s)
        {
            List<char> charList = s.ToCharArray().ToList();
            charList.Sort();
            IEnumerable<IGrouping<char, char>> charSets = charList.GroupBy(c => c);
            List<Dictionary<string, object>> stringMetaData = new List<Dictionary<string, object>>();
            foreach (IGrouping<char, char> letter in charSets)
            {
                stringMetaData.Add(new Dictionary<string, object>
                {
                    { "character", letter.Key },
                    { "count", letter.Count() }
                });
            }
            return stringMetaData;
        }

        public static bool PalindromTest(this string s)
        {
            bool strLenIsEven = s.Length % 2 == 0;
            int halfLen = strLenIsEven ? s.Length / 2 : (s.Length - 1) / 2;
            string firstHalf = s.Substring(0, halfLen);
            string secondHalf = strLenIsEven ? s.Substring(halfLen) : s.Substring(halfLen + 1);
            return firstHalf == ReverseString(secondHalf);
        }

        private static string ReverseString(string s)
        {
            char[] stringAsCharArray = s.ToCharArray();
            Array.Reverse(stringAsCharArray);
            return new string(stringAsCharArray);
        }
    }
}
