using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReadifyKnockKnock.Controllers
{
    public class FibonacciController : ApiController
    {
        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <param name="n">The index (n) of the fibonacci sequence</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(long))]
        public IHttpActionResult Fibonacci(int n)
        {
            try
            {
                return Ok(FibonacciMethod(n));
            }
            catch(Exception /*exception*/)
            {
                // Log the exception.
                return BadRequest();
            }

        }
        private long FibonacciMethod(int n)
        {
            if (n < 0)
                return (int)Math.Pow(-1, n + 1) * FibonacciMethod(-n);

            /*Algorithm Selection */
            return FastFibonacci(n);
        }
        private long FastFibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;

            else if (n == 2)
                return 1;

            else if (n % 2 == 0)
            {
                int k = n / 2;
                long fk = FastFibonacci(k);
                long fkp1 = FastFibonacci(k + 1);
                checked
                {
                    return fk * (2 * fkp1 - fk);
                }
            }
            else
            {
                int k = (n - 1) / 2;
                long fk = FastFibonacci(k);
                long fkp1 = FastFibonacci(k + 1);
                checked
                {
                    return fkp1 * fkp1 + fk * fk;
                }
            }
        }
        private long RecursiveFibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                checked
                {
                    return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
                }
        }
    }
}
