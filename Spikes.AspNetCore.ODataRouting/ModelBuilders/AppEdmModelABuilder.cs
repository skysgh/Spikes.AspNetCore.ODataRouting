using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Models.ModuleA;
using System.Xml.Linq;

namespace Spikes.AspNetCore.ODataRouting.ModelBuilders
{
    public static class AppEdmModelABuilder 
    {
        public static IEdmModel BuildModel()
        {
            var builder = new ODataConventionModelBuilder();

            /*01*/
            // Works, follows convention of part-part == controller name prefix 
            // a) found as an odata controller (under api/odata/v{version}
            // b) acting as an Odata controller (returning odata wrapper in json)
            // c) Queryability works
            builder.EntitySet<SomeBaseParentModel>("ValuesA1");

            /*02*/
            // Works, follows convention of part-part == controller name prefix 
            // Route Attribute is applied, but same as Controller Name prefix, so ignored?
            // a) found as an odata controller (under api/odata/v{version}
            // b) acting as an Odata controller (returning odata wrapper in json)
            // c) Queryability works
            builder.EntitySet<SomeBaseParentModel>("ValuesA2");

            /*03*/
            // Fails, as path-part != controller name prefix
            // and no RouteAttribute to make it work differently: 
            // a) not found as an odata controller (under api/odata/v{version}
            // b) not acting as an Odata controller (returning odata wrapper in json)
            // c) no Queryability
            builder.EntitySet<SomeBaseParentModel>("Renamed3");

            /*04*/
            // Fails, as path-part != Controller name prefix,  
            // but ODataRouteComponent attribute doesn't help 
            // a) not found as an odata controller (under api/odata/v{version}
            // b) not acting as an Odata controller (returning odata wrapper in json)
            // c) no Queryability
            builder.EntitySet<SomeBaseParentModel>("Renamed4");

            /*05*/
            //Half Works!!!
            //Routes as an OData Route
            //Even though path-part != Controller Name prefix
            //because RouteAttribute starts with Convention prefix.
            // a) listed in ~/$odata an odata controller (under api/odata/v{version}
            // b) acting as an Odata controller (returning odata wrapper in json)
            // c) no Queryability
            builder.EntitySet<SomeBaseParentModel>("Renamed5");

            /*06*/
            // Fails.
            // a) not listed in ~/$odata an odata controller (under api/odata/v{version}
            //    ...even if prefixed with odata prefix
            // b) not acting as an Odata controller (returning odata wrapper in json)
            // c) no Queryability
            // Simply because its not following convention?
            builder.EntitySet<SomeBaseParentModel>(AppAPIConstants.ODataPrefixWithSlash + "Renamed6");

            /*07*/
            //Fails.
            // a) not listed in ~/$odata an odata controller (under api/odata/v{version}
            //    ...even if prefixed with odata prefix
            ///Use of a slash confuses it?
            // b) not acting as an Odata controller (returning odata wrapper in json)
            // c) no Queryability
            // Simply because its not following convention?
            builder.EntitySet<SomeBaseParentModel>(AppAPIConstants.ModuleA + "/" + "Renamed7");

            /*08*/
            //Half Works.
            // a) listed in ~/$odata an odata controller (under api/odata/v{version}
            ///Use of a slash confuses it?
            // b) acting as an Odata controller (returning odata wrapper in json)
            // c) but no Queryability
            // But messy naming (but messy) if using a dash to get around  slash:
            builder.EntitySet<SomeBaseParentModel>(AppAPIConstants.ModuleA + "-" + "Renamed8");



            // ie...what the hell is going on?!?

            return builder.GetEdmModel();

        }


    }
}
