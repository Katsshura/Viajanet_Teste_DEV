using Couchbase.Core;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using WebApi.CouchbaseReader.Infrastructure;

namespace WebApi.CouchbaseReader.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrowserInformationController : ControllerBase
    {
        private IBucket _bucket;

        public BrowserInformationController()
        {
            _bucket = CouchbaseConnector.GetBucketInstance();
        }

        // GET: api/BrowserInformation
        [HttpGet]
        public ActionResult GetBrowserInformation([FromQuery] string ip, [FromQuery] string pageName)
        {
            if (ip == null && pageName == null)
            {
                //Return all content in database relationed to browser information

                var statement = @"Select d.* from ViajanetDB d where d.type = 'BrowserInformation';";
                var query = new QueryRequest(statement).ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }

            else if (ip != null && pageName != null)
            {
                //Return all content in database bound to ip and pageName
                var statement = @"Select d.* from ViajanetDB d where d.type = 'BrowserInformation' and d.ip = $ip and d.pageName = $pageName;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("ip", ip)
                    .AddNamedParameter("pageName", pageName)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
            else if (ip != null)
            {
                //Return all content in database bound to ip
                var statement = @"Select d.* from ViajanetDB d where d.type = 'BrowserInformation' and d.ip = $ip;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("ip", ip)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
            else if(pageName != null)
            {
                //Return all content in database bound to pageName
                var statement = @"Select d.* from ViajanetDB d where d.type = 'BrowserInformation' and d.pageName = $pageName;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("pageName", pageName)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
            else
            {
                //Return bad request
                return BadRequest();
            }
        }

        private ActionResult GetDataFromCouchbase(IQueryRequest query)
        {
            var qr = query;
            var result = _bucket.Query<dynamic>(qr);

            if (result != null)
                if (result.Rows.Count > 0)
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
