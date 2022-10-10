using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Spikes.AspNetCore.ODataRouting.Models;
using System.Xml.Linq;

namespace Spikes.AspNetCore.ODataRouting.ModelBuilders
{
    public static class AppEdmModelBuilder 
    {
        public static IEdmModel BuildModel()
        {
            var builder = new ODataConventionModelBuilder();

            /*01*/builder.EntitySet<SomeModel>("Values1");
            /*02*/builder.EntitySet<SomeModel>("Values2");
            /*03*/builder.EntitySet<SomeModel>("Trash3");
            /*04*/builder.EntitySet<SomeModel>("Trash4");
            /*05*/builder.EntitySet<SomeModel>("Trash5");
            /*06*/builder.EntitySet<SomeModel>("api/odata/v{version}/Trash6");
            /*07*/builder.EntitySet<SomeModel>("SomeModuleName/Trash7");
            /*08*/builder.EntitySet<SomeModel>("SomeModuleName_Trash8");

            return builder.GetEdmModel();

        }


    }
}
