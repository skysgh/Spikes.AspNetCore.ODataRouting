using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Spikes.AspNetCore.ODataRouting.Models;

namespace Spikes.AspNetCore.ODataRouting.ModelBuilders
{
    public static class AppEdmModelBuilder 
    {
        public static IEdmModel BuildModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<SomeModel>("Values1");
            builder.EntitySet<SomeModel>("Values2");
            builder.EntitySet<SomeModel>("Trash");

            return builder.GetEdmModel();

        }


    }
}
