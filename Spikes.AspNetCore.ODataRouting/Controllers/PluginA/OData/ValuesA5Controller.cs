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
    // a) listed in ~/$odata as an odata controller (under api/odata/v{version}
    // b) acting as an Odata controller (returning odata wrapper in json)
    // c) no queryability
    // as the route starts with same prefix
    // as Convention used when registereing EDM model
    // But $count doesn't work!
    [Route(AppAPIConstants.ODataPrefixWithSlash + "Renamed5")]
    public class ValuesA5Controller : ODataController
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        [HttpGet("")]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(FakeDataBuilderA.Get());
        }

    }
}
