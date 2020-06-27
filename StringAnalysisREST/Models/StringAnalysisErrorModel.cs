using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringAnalysisREST.Models
{
    public class StringAnalysisErrorModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
