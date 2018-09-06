using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Controllers
{
    using Integartion.Database;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CarSharingContext _db; 

        public ValuesController(CarSharingContext context)
        {
            _db = context;
        }

        [HttpGet("car")]
        public ActionResult<IEnumerable<TestTable>> GetTestEntries()
        {
            return _db.TestTables;
        }

        [HttpPost("car")]
        public async Task<ActionResult> PostEntries(TestTable test)
        {
            _db.TestTables.Add(test);
            await _db.SaveChangesAsync();

            return Ok();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
