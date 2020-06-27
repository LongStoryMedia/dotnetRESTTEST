using System;
using System.Collections.Generic;

namespace StringAnalysisREST.Models
{
    public class StringAnalysisModel
    {
        public bool IsPalindrome{ get; set; }

        public List<Dictionary<string, object>> SortedCharacterCount { get; set; }

        public string TimeStamp { get; set; }
    }
}
