using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReadifyKnockKnock.Controllers
{
    public class ReverseWordsController : ApiController
    {
        /// <summary>
        /// 	Reverses the letters of each word in a sentence.
        /// </summary>
        /// <param name="sentence">A sentence</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult ReverseWords(string sentence = "")
        {
            var words = sentence.Split(' ');
            StringBuilder reversedSentence = new StringBuilder(sentence.Length);
            foreach (string word in words)
            {
                string reversedWord = new string(word.Reverse().ToArray());

                /* Using StringBuilder (mutable type) for the sake of performance.*/

                if (reversedSentence.Length > 0)
                    reversedSentence.Append(' ');

                reversedSentence.Append(reversedWord);
            }
            return Ok(reversedSentence.ToString());
        }
    }
}
