using Couchbase.Core;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using WebApi.CouchbaseReader.Infrastructure;

namespace WebApi.CouchbaseReader.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IBucket _bucket;

        public ProductController()
        {
            _bucket = CouchbaseConnector.GetBucketInstance();
        }


        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var statement = @"Select d.*, Meta(d).id from ViajanetDB d where d.type = 'Product' ORDER BY d.price;";
            var query = new QueryRequest(statement).ScanConsistency(ScanConsistency.RequestPlus);
            return GetDataFromCouchbase(query);
        }

        // GET: api/Product
        [HttpGet("{id}")]
        public ActionResult GetProductById(string id)
        {
            if (id != null)
            {
                var statement = @"Select d.*, Meta(d).id from ViajanetDB d where d.type = 'Product' and Meta(d).id = $id;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("id",id)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        public ActionResult GetProductByTitle([FromQuery] string title)
        {
            if(title == null)
            {
                return BadRequest();
            }
            else
            {
                var statement = @"Select d.*, Meta(d).id from ViajanetDB d where d.type = 'Product' and d.title = $title;";
                var query = new QueryRequest(statement)
                    .AddNamedParameter("title", title)
                    .ScanConsistency(ScanConsistency.RequestPlus);
                return GetDataFromCouchbase(query);
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
