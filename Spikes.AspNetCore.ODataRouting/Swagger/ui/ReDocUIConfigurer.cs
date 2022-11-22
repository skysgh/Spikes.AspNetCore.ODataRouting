using Microsoft.AspNetCore.Builder;
using Spikes.AspNetCore.ODataRouting.Constants;
using Swashbuckle.AspNetCore.ReDoc;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Spikes.AspNetCore.ODataRouting.Swagger.ui
{
    public static class ReDocUIConfigurer {
        public static void Configure(ReDocOptions c)
        {
            c.DocumentTitle = "Bugger...";



            //c.InjectStylesheet("/redoc/ui/customstylesheet.css");
            //c.IndexStream = () =>
            //{
            //    var r =
            //    System.Reflection.Assembly.GetExecutingAssembly()
            //            .GetManifestResourceStream
            //   ("Spikes.AspNetCore.ODataRouting.Embedded.Swagger.index.html");
            //    return r;
            //};

            //Ensure starts with slash:
            c.SpecUrl = $"{AppAPIConstants.OpenAPI.Spec.FileRoot}/{AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.Rest.ID}/{AppAPIConstants.OpenAPI.Spec.FileName}";
            //c.SpecUrl = $"{AppAPIConstants.OpenAPI.SwaggerJSonRoot}/{AppAPIConstants.PluginODataAPIsID}/{AppAPIConstants.OpenAPIFileName}";
            //c.SpecUrl = $"{AppAPIConstants.OpenAPI.SwaggerJSonRoot}/{AppAPIConstants.BaseFailedODataAPIsID}/{AppAPIConstants.OpenAPIFileName}";
            //c.SpecUrl = $"{AppAPIConstants.OpenAPI.SwaggerJSonRoot}/{AppAPIConstants.PluginODataAPIsID}/{AppAPIConstants.OpenAPIFileName}";

            //Several configuration options available:
            //c.ConfigObject.DisableSearch = true;
            //etc.
            c.RoutePrefix = AppAPIConstants.OpenAPI.UI.ReDoc.ReDocRoot;
        }

    }
}
