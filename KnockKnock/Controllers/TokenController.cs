using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReadifyKnockKnock.Controllers
{
    public class TokenController : ApiController
    {
        public const string MyToken = "df1706ec-260f-443e-92e6-444bb52253b9";

        /// <summary>
        /// Mohammad Chamanpara's Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult Token()
        {
            /* My enchanted token. */
            return Ok(MyToken);
        }

    }
}
