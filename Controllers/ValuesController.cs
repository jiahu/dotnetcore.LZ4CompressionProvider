using System.Collections.Generic;
using hu.jia.ZippedWebAPI.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace hu.jia.ZippedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhostOrigin")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [LoggingFilter(Arguments = new object[] { "API 'api/values' called" })]
        public IEnumerable<string> Get()
        {
            return new string[] {
                "Created the lz4 compression stream 001",
                "Created the lz4 compression stream 002",
                "Created the lz4 compression stream 003",
                "Created the lz4 compression stream 004",
                "Created the lz4 compression stream 005",
                "Created the lz4 compression stream 006",
                "Created the lz4 compression stream 007"
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
