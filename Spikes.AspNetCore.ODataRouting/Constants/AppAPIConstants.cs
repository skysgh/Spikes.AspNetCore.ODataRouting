namespace Spikes.AspNetCore.ODataRouting.Constants
{

    public partial class AppAPIConstants
    {
        public class OData {
            //Note that we're ending it with a slash to 
            //make concatenantion work 
            // with subsequent Module names below:
            public const string ODataPrefix = "api/OData/v{version}";
        }

        public class OpenAPI
        {
            public class Spec
            {

                //Must not end with slash (so also must not be '/')
                //And if no start slash, will be relative to above docs:
                //but if slash included, will be relative to root:
                //And in general, probably best to stick to something generic.
                //so...?
                public const string FileRoot = "/openAPI";

                public const string FileName = "openapi.json";//swagger.json
            }
            public class Generation
            {
                public class Areas
                {
                    public class ModuleA
                    {
                        public class Rest
                        {
                            public const string ID = "BaseRestV1";
                            public const string Title = "Base Standard REST APIs";
                        }
                        public class OData
                        {
                            public const string ID = "BaseODataV1";
                            public const string Title = "Base OData APIs";
                            public class Failed
                            {
                                public const string ID = "BaseODataV0";
                                public const string Title = "Base (Failing) OData APIs";
                            }
                        }
                    }
                    public class ModuleB
                    {
                        public class Rest
                        {
                        }
                        public class OData
                        {
                            public const string ID = "PluginODataV1";
                            public const string Title = "PluginB OData APIs";
                            public class Failed
                            {
                            }
                        }
                    }

                }

            }


            public class UI
            {
                public class Swagger
                {
                    //Must not end with slash (so also must not be '/')
                    //And this one must not start with a slash either:
                    //IMPORTANT: When you change this, you also have to change
                    //matching string in "launchUrl": "docs/api/swagger" 
                    //setting within launchsettings.json
                    public const string SwaggerDocRoot = "docs/api/swagger";
                }
                public class ReDoc
                {
                    public const string ReDocRoot = "docs/api/redoc";
                }

            }

        }

        public class Modules { 
            public class ModuleA
            {
                public const string Name = "ModuleA";
                public const string ODataPrefix = $"api/odata/{Name}/v{{version}}";
                //$"{OData.ODataPrefix}/{Name}";
                public class Controllers {
                    public static string Controller1 = null;
                }

            }

            public class ModuleB
            {
                public const string Name = "ModuleB";
                public const string ODataPrefix = $"api/odata/{Name}/v{{version}}";
                    //$"{OData.ODataPrefix}/{Name}";


            }
        }






    }
}
