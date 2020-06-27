using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using StringAnalysisREST.Models;

namespace StringAnalysisREST.Controllers
{
    [ApiController]
    [Route("{s?}")]
    public class StringAnalysisController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string s = "")
        {
            try
            {
                if (s.Length == 0)
                {
                    throw new ArgumentException("string parameter missing");
                }
                if (!Regex.IsMatch(s, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentException("string parameter should only contain letters");
                }
                return Ok(new StringAnalysisModel
                {
                    TimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    IsPalindrome = s.PalindromTest(),
                    SortedCharacterCount = s.GetStringMetaData()
                });
            }
            catch (ArgumentException e)
            {
                return ErrorStatus(e.Message, (int)HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return ErrorStatus(e.Message, (int)HttpStatusCode.NotFound);
            }
        }

        private ObjectResult ErrorStatus(string message, int errorCode)
        {
            return StatusCode(errorCode, new StringAnalysisErrorModel
            {
                Message = message,
                StatusCode = errorCode
            });
        }
    }
}
