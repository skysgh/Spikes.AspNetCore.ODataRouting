using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Conventions;
using Spikes.AspNetCore.ODataRouting.ModelBuilders;
using Spikes.AspNetCore.ODataRouting.ReDoc;
using Spikes.AspNetCore.ODataRouting.Reset;
using Spikes.AspNetCore.ODataRouting.Swagger.Filters;
using Spikes.AspNetCore.ODataRouting.Swagger.json;
using Spikes.AspNetCore.ODataRouting.Swagger.ui;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Buffers.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace Spikes.AspNetCore.ODataRouting
{
    public static class Singletons { 
        public static WebApplicationBuilder Builder { get; set; }
    }

    public class Program
    {

        public static void Main(string[] args)
        {
            WebApplicationBuilder webApplicationBuilder = 
                WebApplication.CreateBuilder(args);
            // Add services to the container.

            // Note how we us a Builder we created to 
            // offload the assembly of the edmModel:
            var edmModelA = AppEdmModelABuilder.BuildModel();
            var edmModelB = AppEdmModelBBuilder.BuildModel();

            // Hack save to get access to it later in 
            // the 'upload' controller:
            Singletons.Builder = webApplicationBuilder;

            // Note we are adding Odata,
            // nothins special going on
            // bar putting using the Convention 
            // of having a prefix for API controllers:
            var mvcBuilder = webApplicationBuilder
                            .Services
                            .AddControllers()
                            .AddOData(
                                opt =>
                                opt
                                .Count()
                                .Filter()
                                .Expand()
                                .Select()
                                .OrderBy()
                                .SetMaxTop(5)
                                //Add Module/PluginA Routes:
                                .AddRouteComponents(
                                     AppAPIConstants.Modules.ModuleA.ODataPrefix,
                                     edmModelA)
                                //Add Module/PluginB Routes:
                                //.AddRouteComponents(
                                //   AppAPIConstants.Modules.ModuleB.ODataPrefix,
                                //   edmModelB)
                                //Uses AttributeRoutingConvention:
                                .EnableAttributeRouting = true
                                );

            var check = 
                webApplicationBuilder
                .Services
                .Where(x=>
                    x
                    .ServiceType
                    .Name
                    .Contains("OData"))
                    .ToArray();

            webApplicationBuilder.Services.AddEndpointsApiExplorer();

            // Note putting in routes to 
            // http://localhost/$odata
            // and 
            // http://localhost/{$"{AppAPIConstants.SwaggerDocRoot}/swagger/index.html


            // Learn more about configuring
            // Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            webApplicationBuilder.Services
                .AddSwaggerGen(
                SwaggerConfigurer.BuildSwaggerGenOptions);

            //Register the path resetter:
            webApplicationBuilder.Services.AddSingleton<IActionDescriptorChangeProvider>(AppActionDescriptorChangeProvider.Instance);
            //builder.Services.AddSingleton(AppActionDescriptorChangeProvider.Instance);

            var app = webApplicationBuilder.Build();

            ServiceProvider s = (ServiceProvider)app.Services;
            
            //Doesn't work:
            //var cxxx = app.Services.GetService<IMvcBuilder>();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(c=>
                {
                    
                    //NOTE: First {} is dynamic
                    //      Second is template token
                    //      ...not the same thing...
                    c.RouteTemplate = 
                    $"{AppAPIConstants.OpenAPI.Spec.FileRoot}/"+
                    "{documentname}/"+
                    $"{AppAPIConstants.OpenAPI.Spec.FileName}";
                });


                CheckManifests();

                app.UseSwaggerUI(SwaggerUIConfigurer.Configure);

                app.UseReDoc( ReDocUIConfigurer.Configure);
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            //app.UseAuthorization();

            //Enable the `~/odata route:
            app.UseODataRouteDebug();

            app.UseRouting();

            //IList<IODataRoutingConvention> conventions = ODataRoutingConventions.CreateDefaultWithAttributeRouting(configuration, model);
            //conventions.Insert(0, new CustomPropertyRoutingConvention());
            //configuration.MapODataServiceRoute("odata", "odata", model, new DefaultODataPathHandler(), conventions);

            app.MapControllers();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            var routeCollection = app.Services.GetService<IRouteCollection>();
            //var oDataPathHandler = app.Services.GetService<IOdata>();


            app.Run();
        }

        private static void CheckManifests()
        {
            var check3 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }
}