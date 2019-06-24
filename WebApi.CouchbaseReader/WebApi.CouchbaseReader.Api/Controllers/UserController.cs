using Couchbase.Core;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using WebApi.CouchbaseReader.Infrastructure;

namespace WebApi.CouchbaseReader.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBucket _bucket;

        public UserController()
        {
            _bucket = CouchbaseConnector.GetBucketInstance();
        }
        // GET: api/User
        [HttpGet("{id}")]
        public ActionResult GetUserProfile(string id)
        {
            //Get User Profile by ID

            if (id != null)
            {
                var statement = @"Select d.*, Meta(d).id from ViajanetDB d where d.type = 'User' and Meta(d).id = $id;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("id", id)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        public ActionResult GetUserByEmailAndPassword([FromQuery] string email, [FromQuery] string pass)
        {
            if (email == null || pass == null)
            {
                return BadRequest();
            }
            else
            {
                var statement = @"Select d.*, Meta(d).id from ViajanetDB d where d.type = 'User' and d.email = $email and d.pass = $pass;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("email", email)
                    .AddNamedParameter("pass", pass)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
        }

        [HttpGet("getemail")]
        public ActionResult GetUserEmail([FromQuery] string email)
        {
            if(email == null)
            {
                return BadRequest();
            }
            else
            {
                var statement = @"Select d.email from ViajanetDB d where d.type = 'User' and d.email = $email;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("email", email)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
        }

        private ActionResult GetDataFromCouchbase(IQueryRequest query)
        {
            var qr = query;
            var result = _bucket.Query<dynamic>(qr);

            if (result != null)
                if(result.Rows.Count > 0)
                {
                    return Ok(result.Rows);
                }
                else
                {
                    return NoContent();
                }
            return NoContent();
        }
    }
}
