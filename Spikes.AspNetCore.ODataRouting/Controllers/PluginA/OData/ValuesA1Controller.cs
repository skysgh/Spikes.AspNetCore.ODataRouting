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
        /// Some bullshit description about the Endpoint
        /// <para>
        /// An example of code would be:
        /// <code>
        /// <![CDATA[
        ///  {
        ///    var x = new Foo(); 
        ///  }
        /// ]]>
        /// </code>
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The better place to put code is in Remarks
        /// <![CDATA[
        ///  {
        ///    var x = new Boo(); 
        ///  }
        /// ]]>
        /// or 
        /// <code>
        /// <![CDATA[
        ///  {
        ///    var x = new Boo(); 
        ///  }
        /// ]]>
        /// </code>
        /// </para>
        /// </remarks>
        [HttpGet("")]
        [HttpGet("Get")]
        [EnableQuery(PageSize = 100)]
        //Specify results
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //For Swagger:
        [ApiExplorerSettings(GroupName=AppAPIConstants.BaseODataAPIsID)]
        public IActionResult Get()
        {
            return Ok(FakeDataBuilderA.Get());
        }



    }
}
