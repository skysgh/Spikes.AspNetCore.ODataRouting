namespace Spikes.AspNetCore.ODataRouting.Constants
{
    public static class AppAPIConstants
    {
        //Note that we're ending it with a slash to 
        //make concatenantion work 
        // with subsequent Module names below:
        public const string ODataPrefixWithOutSlash = "api/OData/v{version}";
        public const string ODataPrefixWithSlash = ODataPrefixWithOutSlash + "/";

        public const string ModuleA = "ModuleA";
        public const string ModuleB = "ModuleB";

        public const string BaseRESTAPIsID = "BaseRestV1";
        public const string BaseRESTAPIsTitle = "Base Standard REST APIs";
        public const string BaseODataAPIsID = "BaseODataV1";
        public const string BaseODataAPIsTitle = "Base OData APIs";
        public const string BaseFailedODataAPIsID= "BaseODataV0";
        public const string BaseFailedODataAPIsTitle = "Base (Failing) OData APIs";

        public const string PluginODataAPIsID = "PluginODataV1";
        public const string PluginODataAPIsTitle = "PluginB OData APIs";


        //Must not end with slash (so also must not be '/')
        //And this one must not start with a slash either:
        //IMPORTANT: When you change this, you also have to change
        //matching string in "launchUrl": "docs/api/swagger" 
        //setting within launchsettings.json
        public const string SwaggerDocRoot = "docs/api/swagger";
        //Must not end with slash (so also must not be '/')
        //And if no start slash, will be relative to above docs:
        //but if slash included, will be relative to root:
        //And in general, probably best to stick to something generic.
        //so...?
        public const string SwaggerJSonRoot = "/openAPI";

        public const string SwaggerFileName = "openapi.json";//swagger.json


        public const string ReDocRoot = "docs/api/redoc";

    }
}
