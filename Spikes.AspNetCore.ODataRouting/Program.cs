using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Conventions;
using Spikes.AspNetCore.ODataRouting.ModelBuilders;
using System.Reflection;
using System.Reflection.Emit;

namespace Spikes.AspNetCore.ODataRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Note how we us a Builder we created to 
            // offload the assembly of the edmModel:
            var edmModelA = AppEdmModelABuilder.BuildModel();

            var edmModelB = AppEdmModelBBuilder.BuildModel();

            // Note we are adding Odata, 
            // nothins special going on
            // bar putting using the Convention 
            // of having a prefix for API controllers:
            var mvcBuilder = builder.Services
                            .AddControllers()
                            .AddOData(
                                opt =>
                                opt.Count()
                                .Filter()
                                .Expand()
                                .Select()
                                .OrderBy()
                                .SetMaxTop(5)
                                //Add Module/PluginA Routes:
                                .AddRouteComponents(
                                     AppAPIConstants.ODataPrefixWithSlash,
                                    edmModelA)
                                //Add Module/PluginB Routes:
                                .AddRouteComponents(
                                     AppAPIConstants.ODataPrefixWithSlash + "MODULEB/",
                                    edmModelB)
                                //Uses AttributeRoutingConvention:
                                .EnableAttributeRouting = true
                )
                            ;



            builder.Services.AddEndpointsApiExplorer();

            // Note putting in routes to 
            // http://localhost/$odata
            // and 
            // http://localhost/swagger/index.html


            // Learn more about configuring
            // Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

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

            app.Run();
        }
    }
}