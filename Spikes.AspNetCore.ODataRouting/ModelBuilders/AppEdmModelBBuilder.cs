using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Models.ModuleBase;
using System.Xml.Linq;

namespace Spikes.AspNetCore.ODataRouting.ModelBuilders
{
    public static class AppEdmModelBBuilder 
    {
        public static IEdmModel BuildModel()
        {
            var builder = new ODataConventionModelBuilder();

            /*01*/
            // Works, follows convention of part-part == controller name prefix 
            builder.EntitySet<SomeBaseParentModel>("ValuesB1");

            return builder.GetEdmModel();

        }


    }
}
