using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramChecker;
using System.Web;

namespace AnagramCheckerAPI.Controllers
{
    [ApiController]
    public class AnagramCheckerController : ControllerBase
    {

        [HttpGet]
        [Route("checkAnagram")]
        public IActionResult GetCheckAnagram([FromBody] Words words)
        {
            bool result = AnagramChecker.Class1.CheckAnagram(words.w1, words.w2);
            if (result)
            {
                return Ok("It's a Anagram");
            }

            return BadRequest("No Anagram Found");
        }

        [HttpGet]
        [Route("getKnownAnagrams")]
        public IActionResult GetKnownAnagrams([FromQuery] string w)
        {
            List<string> results = AnagramChecker.Class1.FindAnagram(w);
            return Ok(results);
        }
    }
}
