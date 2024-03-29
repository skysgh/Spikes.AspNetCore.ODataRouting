﻿using Microsoft.AspNetCore.Http;
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
    // because doesn't have prefix equal
    // to "api/odata/v{version}" that is defined
    // when model registered.
    // As ODataRouteComponent only affects Convention
    // based, not Attribute based. Whatever that means.
    [ODataRouteComponent(AppAPIConstants.Modules.ModuleA.ODataPrefix)]
    [Route("Renamed4")]
    //For Swagger:
    [ApiExplorerSettings(GroupName = AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.OData.Failed.ID)]
    public class ValuesA4Controller : ODataController
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
