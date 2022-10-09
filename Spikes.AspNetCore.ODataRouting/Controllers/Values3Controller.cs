using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Spikes.AspNetCore.ODataRouting.Controllers
{
    [ODataAttributeRouting]
    // Fails because doesn't have prefix equal
    // to "api/odata/v{version}" that is defined
    // when model registered.
    [Route("Trash3")]
    public class Values3Controller : ODataController
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [HttpGet("Get")]
        [EnableQuery(PageSize = 100)]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
