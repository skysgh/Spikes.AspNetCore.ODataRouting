using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Spikes.AspNetCore.ODataRouting.Singleton;

namespace Spikes.AspNetCore.ODataRouting.Controllers.PluginA.OData
{
    [ODataAttributeRouting]
    // Works
    // a) listed in ~/$odata as an odata controller (under api/odata/v{version}
    // b) acting as an Odata controller (returning odata wrapper in json)
    // c) Queryability works
    // ie Matches convention...so works
    // But not what we want as brittle
    // If you rename class, will blow up clients.
    public class ValuesA1Controller : ODataController
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
            return Ok(FakeDataBuilder.Get());
        }



    }
}
