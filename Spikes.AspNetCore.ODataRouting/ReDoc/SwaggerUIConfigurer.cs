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
            c.SwaggerEndpoint($"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.BaseRESTAPIsID}/{AppAPIConstants.SwaggerFileName}", "Base Rest APIs");
            c.SwaggerEndpoint($"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.PluginODataAPIsID}/{AppAPIConstants.SwaggerFileName}", "Base OData APIs");
            c.SwaggerEndpoint($"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.BaseFailedODataAPIsID}/{AppAPIConstants.SwaggerFileName}", "Base OData (Failed) APIs");
            c.SwaggerEndpoint($"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.PluginODataAPIsID}/{AppAPIConstants.SwaggerFileName}", "Plugin OData APIs");

            c.RoutePrefix = AppAPIConstants.SwaggerDocRoot;
        }
    }
}
