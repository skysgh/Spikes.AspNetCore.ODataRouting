using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Swagger.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Spikes.AspNetCore.ODataRouting.Swagger.json
{
    public static class SwaggerConfigurer
    {

        public static void BuildSwaggerGenOptions(SwaggerGenOptions options)
        {
            //As per
            // https://stackoverflow.com/questions/70472622/how-to-hide-odata-metadata-controller-in-swagger
            options.DocumentFilter<AppSwaggerODataControllerDocumentFilter>();

            // Include the commments:
            // using System.Reflection;
            // as per https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
            if (File.Exists(xmlFilePath))
            {
                // Don't forget true flag to include comments from
                // controllers:
                // Tip: https://stackoverflow.com/questions/50511071/how-to-define-controller-descriptions-in-asp-net-core-swagger-swashbuckle-aspne
                options.IncludeXmlComments(xmlFilePath,true);
            }


            BuildSwaggerGenOptionsBaseRest(options);
            BuildSwaggerGenOptionsBaseOData(options);
            BuildSwaggerGenOptionsBaseODataFails(options);

            BuildSwaggerGenOptionsPluginOData(options);

        }

        static void BuildSwaggerGenOptionsBaseRest(SwaggerGenOptions configuration)
        {

            configuration.SwaggerDoc(AppAPIConstants.BaseRESTAPIsID,
                new OpenApiInfo
                {

                    Title = AppAPIConstants.BaseRESTAPIsTitle,
                    Version = "v1",
                    Description = "The App's standard REST APIs",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });



        }
        static void BuildSwaggerGenOptionsBaseOData(SwaggerGenOptions result)
        {
            result.SwaggerDoc(AppAPIConstants.BaseODataAPIsID, new OpenApiInfo
            {
                Version = "v1",

                Title = AppAPIConstants.BaseODataAPIsTitle,
                Description = "The Apps Base OData APIs (that work)",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });
        }
        static void BuildSwaggerGenOptionsBaseODataFails(SwaggerGenOptions result)
        {
            result.SwaggerDoc(AppAPIConstants.BaseFailedODataAPIsID, new OpenApiInfo
            {
                Version = "v1",

                Title = AppAPIConstants.BaseFailedODataAPIsTitle,
                Description = "The Apps Base OData APIs (that don't work well)",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });
        }
        static void BuildSwaggerGenOptionsPluginOData(SwaggerGenOptions result)
        {
            result.SwaggerDoc(AppAPIConstants.PluginODataAPIsID, new OpenApiInfo
            {
                Version = "v1",

                Title = AppAPIConstants.PluginODataAPIsTitle,
                Description = "The Apps Plugin OData APIs (that work)",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });
        }

    }
}