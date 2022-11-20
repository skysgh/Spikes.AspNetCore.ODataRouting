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
    // Fails
    // a) not listed in ~/$odata found as an odata controller (under api/odata/v{version}
    //    ...even though route looks like odata prefixed...
    // b) but not acting as an Odata controller (returning odata wrapper in json)
    // c) no Queryability 
    [Route(AppAPIConstants.ODataPrefixWithSlash + "Renamed6")]
    //For Swagger:
    [ApiExplorerSettings(GroupName = AppAPIConstants.BaseFailedODataAPIsID)]
    public class ValuesA6Controller : ODataController
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
            return Ok(FakeDataBuilderA.Get());
        }

    }
}
