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
    // Matches convention...so should work
    // but when brought included in system, 
    // it causes an error in Swagger.
    // saying 
    /*
     * SwaggerGeneratorException: 
     * Conflicting method/path combination "GET " for actions - 
     * Spikes.AspNetCore.ODataRouting.Controllers.PluginA.OData.ValuesA1Controller.Get 
     * (Spikes.AspNetCore.ODataRouting),
     * Spikes.AspNetCore.ODataRouting.Controllers.PluginA.OData.ValuesB1Controller.Get 
     * (Spikes.AspNetCore.ODataRouting). 
     * Actions require a unique method/path combination for 
     * Swagger/OpenAPI 3.0. Use ConflictingActionsResolver as a workaround
     * 
     * WHY THE HELL NOT?!
     * IT IS A DIFFERENT CONTROLLER NAME
     * SO SHOULD BE FINE, NO?
     */

    // If you forget to add this, on more than two Controllers
    // you'll get an error that the routes ("Get") conflict
    // as they both have no prefix.
    [Route(AppAPIConstants.ODataPrefixWithSlash + AppAPIConstants.ModuleB +"/" + "RenamedB1")]
    public class ValuesB1Controller : ODataController
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [HttpGet("Get")]
        [EnableQuery(PageSize = 100)]

        [ApiExplorerSettings(GroupName = AppAPIConstants.PluginODataAPIsID)]
        public IActionResult Get()
        {
            return Ok(FakeDataBuilderB.Get());
        }



    }
}
