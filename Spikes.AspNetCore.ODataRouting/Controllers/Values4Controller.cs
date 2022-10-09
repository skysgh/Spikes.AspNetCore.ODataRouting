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
    // As ODataRouteComponent only affects Convention
    // based, not Attribute based.
    [ODataRouteComponent("api/odata/v{version}/")]
    [Route("Trash4")]
    public class Values4Controller : ODataController
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
