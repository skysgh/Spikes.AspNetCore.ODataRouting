using Spikes.AspNetCore.ODataRouting.Constants;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Spikes.AspNetCore.ODataRouting.ReDoc
{

    public static class SwaggerUIConfigurer
    {
        public static void Configure(SwaggerUIOptions c)
        {
            //c.RoutePrefix = "docs";
            c.DocumentTitle = "Bugger...";
            //c.EnableDeepLinking = true;
            //c.EnableFilter = true;
            //Hide the models (Important. Note the plural on models):
            // As per https://stackoverflow.com/questions/57138564/how-to-hide-the-models-section-in-swagger-ui
            c.DefaultModelsExpandDepth(0);


            c.InjectStylesheet("/swagger/ui/customstylesheet.css");
            c.IndexStream = () =>
            {
                var r =
                System.Reflection.Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream
               ("Spikes.AspNetCore.ODataRouting.Embedded.Swagger.index.html");
                return r;
            };

            //Ensure starts with slash:
            c.SwaggerEndpoint($"{AppAPIConstants.OpenAPI.Spec.FileRoot}/{AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.Rest.ID}/{AppAPIConstants.OpenAPI.Spec.FileName}", "Base Rest APIs");
            c.SwaggerEndpoint($"{AppAPIConstants.OpenAPI.Spec.FileRoot}/{AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.OData.ID}/{AppAPIConstants.OpenAPI.Spec.FileName}", "Base OData APIs");
            c.SwaggerEndpoint($"{AppAPIConstants.OpenAPI.Spec.FileRoot}/{AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.OData.Failed.ID}/{AppAPIConstants.OpenAPI.Spec.FileName}", "Base OData (Failed) APIs");

            c.SwaggerEndpoint($"{AppAPIConstants.OpenAPI.Spec.FileRoot}/{AppAPIConstants.OpenAPI.Generation.Areas.ModuleB.OData.ID}/{AppAPIConstants.OpenAPI.Spec.FileName}", "Plugin OData APIs");

            c.RoutePrefix = AppAPIConstants.OpenAPI.UI.Swagger.SwaggerDocRoot;
        }
    }
}
