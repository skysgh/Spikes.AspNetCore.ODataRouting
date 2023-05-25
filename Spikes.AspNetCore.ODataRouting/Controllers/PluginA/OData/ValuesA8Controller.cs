using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.FakeDataBuilders;

namespace Spikes.AspNetCore.ODataRouting.Controllers.PluginA.OData
{
    [ODataAttributeRouting]
    // Half Works
    // a) listed in ~/$odata found as an odata controller (under api/odata/v{version}
    // b) acting as an Odata controller (returning odata wrapper in json)
    // But Queryability not working.
    //Because
    // Works as long as we don't add a slash (section)
    // by using a dash instead.
    // pretty ugly.

    [Route($"{AppAPIConstants.Modules.ModuleA.ODataPrefix}-Renamed8")]
    //For Swagger:
    [ApiExplorerSettings(GroupName = AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.OData.ID)]
    public class ValuesA8Controller : ODataController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        [HttpGet("")]
        [HttpGet("Get")]
        [HttpGet("$count")]
        [ApiExplorerSettings(GroupName = AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.OData.ID)]
        public IActionResult Get()
        {
            return Ok(FakeDataBuilderA.Get());
        }

    }
}
