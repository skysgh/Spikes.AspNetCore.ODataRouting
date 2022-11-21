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
            c.SpecUrl = $"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.BaseRESTAPIsID}/{AppAPIConstants.SwaggerFileName}";
            //c.SpecUrl = $"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.PluginODataAPIsID}/{AppAPIConstants.SwaggerFileName}";
            //c.SpecUrl = $"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.BaseFailedODataAPIsID}/{AppAPIConstants.SwaggerFileName}";
            //c.SpecUrl = $"{AppAPIConstants.SwaggerJSonRoot}/{AppAPIConstants.PluginODataAPIsID}/{AppAPIConstants.SwaggerFileName}";

            //Several configuration options available:
            //c.ConfigObject.DisableSearch = true;
            //etc.
            c.RoutePrefix = AppAPIConstants.ReDocRoot;
        }

    }
}
