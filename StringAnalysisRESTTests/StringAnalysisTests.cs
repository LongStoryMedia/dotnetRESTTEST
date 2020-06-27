using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringAnalysisREST.Controllers;
using StringAnalysisREST;
using System.Net;

namespace StringAnalysisRESTTests
{
    [TestClass]
    public class StringAnalysisTests
    {
        [TestMethod]
        public void ActionResult_MissingParameter_ReturnsFiveHundredStatusCode()
        {
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, GetTest("").StatusCode);
        }
        [TestMethod]
        public void ActionResult_CorrectlyIdentifiesPalindroms()
        {
            Assert.IsTrue("tacocat".PalindromTest());
            Assert.IsTrue("qwertyytrewq".PalindromTest());
        }
        private ObjectResult GetTest(string s)
        {
            return (ObjectResult)new StringAnalysisController().Get(s);
        }
    }
}
