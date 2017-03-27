using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReadifyKnockKnock.Controllers
{
    public class TriangleTypeController : ApiController
    {
        public enum TriangleTypes { Equilateral , Isosceles, Scalene, Error };

        /// <summary>
        /// Returns the type of triange given the lengths of its sides
        /// </summary>
        /// <param name="a">The length of side a</param>
        /// <param name="b">The length of side b</param>
        /// <param name="c">The length of side c</param>
        /// <returns>Type of triangle</returns>
        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult TriangleType(int a, int b, int c)
        {
            var sides = new List<int> { a, b, c };
            sides.Sort();

            /* Triangle inequality https://en.wikipedia.org/wiki/Triangle_inequality */

            if (sides[0] + sides[1] <= sides[2])
                return Ok(TriangleTypes.Error.ToString());

            if (sides[0] == sides[2])
                return Ok(TriangleTypes.Equilateral.ToString());

            if (sides[0] == sides[1] || sides[1] == sides[2])
                return Ok(TriangleTypes.Isosceles.ToString());

            return Ok(TriangleTypes.Scalene.ToString());
        }
    }
}
