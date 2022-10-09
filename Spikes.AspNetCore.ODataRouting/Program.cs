using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Spikes.AspNetCore.ODataRouting.ModelBuilders;
using System.Reflection.Emit;

namespace Spikes.AspNetCore.ODataRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var catwalkModel = AppEdmModelBuilder.BuildModel();


            builder.Services.AddControllers()
                            .AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5)
                            .AddRouteComponents(
                                "api/odata/",
                                catwalkModel)
                );


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
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

            app.UseODataRouteDebug();

            app.MapControllers();


            app.Run();
        }
    }
}