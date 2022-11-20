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
    // a) not listed in ~/$odata as an odata controller (under api/odata/v{version}
    // b) not acting as an Odata controller (returning odata wrapper in json)
    // c) no Queryability
    // Not acting as an odata controller because
    // doesn't have prefix equal to convention root
    // (ie "api/odata/v{version}"
    // that is defined
    // when model registered.
    [Route("Renamed3")]
    public class ValuesA3Controller : ODataController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [HttpGet("Get")]
        [EnableQuery(PageSize = 100)]
        //For Swagger:
        [ApiExplorerSettings(GroupName = AppAPIConstants.BaseFailedODataAPIsID)]
        public IActionResult Get()
        {
            return Ok(FakeDataBuilderA.Get());
        }

    }
}
