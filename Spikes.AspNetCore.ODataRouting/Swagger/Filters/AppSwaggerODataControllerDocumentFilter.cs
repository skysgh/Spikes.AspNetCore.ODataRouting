using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Spikes.AspNetCore.ODataRouting.Swagger.Filters
{
    //As per https://stackoverflow.com/questions/70472622/how-to-hide-odata-metadata-controller-in-swagger
    public class AppSwaggerODataControllerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Maybe depending on which doc?
            //if (context.DocumentName != openAPI doc){

            // remove controller
            foreach (ApiDescription apiDescription in context.ApiDescriptions)
            {
                var actionDescriptor = (ControllerActionDescriptor)apiDescription.ActionDescriptor;
                if (actionDescriptor.ControllerName == "Metadata")
                {
                    swaggerDoc.Paths.Remove($"/{apiDescription.RelativePath}");
                }
            }

            // remove schemas
            foreach ((string key, _) in swaggerDoc.Components.Schemas)
            {
                if (key.Contains("Edm") || key.Contains("OData"))
                {
                    swaggerDoc.Components.Schemas.Remove(key);
                }
            }
            //}
        }
    }
}
