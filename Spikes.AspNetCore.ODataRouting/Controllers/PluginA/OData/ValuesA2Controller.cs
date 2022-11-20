using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.FakeDataBuilders;

namespace Spikes.AspNetCore.ODataRouting.Controllers.PluginA.OData
{
    //Fails
    // a) listed in ~/$odata listed as an odata controller (under api/odata/v{version}
    // b) acting as an Odata controller (returning odata wrapper in json)
    // c) no Queryability
    //but as attribute = controller name
    //not getting any advantage yet.
    [ODataAttributeRouting]
    [Route("ValuesA2")]
    public class ValuesA2Controller : ODataController
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [HttpGet("Get")]
        [EnableQuery(PageSize = 100)]
        //For Swagger:
        [ApiExplorerSettings(GroupName = AppAPIConstants.BaseODataAPIsID)]
        public IActionResult Get()
        {
            return Ok(FakeDataBuilderA.Get());
        }

    }
}
