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
    }
}
