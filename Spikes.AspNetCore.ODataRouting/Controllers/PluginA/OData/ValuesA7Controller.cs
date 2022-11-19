﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Singleton;

namespace Spikes.AspNetCore.ODataRouting.Controllers.PluginA.OData
{
    [ODataAttributeRouting]
    // Fails
    // a) not listed in ~/$odata found as an odata controller (under api/odata/v{version}
    //    ...even though route looks like odata prefixed...
    // b) not acting as an Odata controller (returning odata wrapper in json)
    // c) Queryability not working
    //Because
    //Adding a Prefix in the mix...
    //which adds a slash ...
    //so it fails, even if matching how it's
    // registered in the EDM model.
    [Route(AppAPIConstants.ODataPrefixWithSlash + AppAPIConstants.ModuleA + "/" + "Renamed7")]
    public class ValuesA7Controller : ODataController
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
