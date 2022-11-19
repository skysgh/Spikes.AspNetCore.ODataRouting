using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.AspNetCore.OData.Routing.Parser;

namespace Spikes.AspNetCore.ODataRouting.Conventions
{
    public class AppCustomAttributeRoutingConvention : AttributeRoutingConvention
    {
        public AppCustomAttributeRoutingConvention(ILogger<AttributeRoutingConvention> logger, IODataPathTemplateParser parser) : base(logger, parser)
        {
        }
    }

}
