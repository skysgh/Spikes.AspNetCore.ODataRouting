# Spikes.AspNetCore.ODataRouting

An experimental Spike to explore 
how to control OData Routing beyond 
defaults.

## Background ##
As APIs are external contracts, it is *very* important
that before embarking on using a library/convention, 
one can back out, change things as needed if they come up.

OData takes care of a lot of things, based on Convention.
Convention is great...until it's not, and one needs finer
control.

By convention, ODataControllers are beregistered as part
  of an EDM model using the Controllers Prefix
  (eg: `Values1` for `Values1Controller`)
  Obviously this is highly brittle and prone to disaster
  if anyone refactors controller names.

  Not only is it brittle, after a while it's probable that one
  will have need for two controllers with the same name, but 
  in different namespaces/areas/modules.
  This is especially the case when developing a Plugin based
  app, where 3rd parties develop their own controllers
  without regard/knowledge of others using the same name

So this is an investigation of 
- how to start off with a common prefix (`~api/odata/v{version}`)
- step a, register controllers with different routes than
  the Controller Name prefix.
- step 2, inject a prefix (the plugin name) into the route before
  the controller name part, to disambiguate
  one controller from another with the same name.
- Doing all that while ensuring Swagger and other tools 
  don't keel over as it is prone to do with OData when you don't 
  get everything right.

## Development Notes
Notes:

- Use of a Builder (`AppEdmModelBuilder`) to create the 
  EDM model.
- The Edm Builder references all the Controllers that are
  registered. 
- The notes in the builder show why some work and some don't.

## Investigation Routes
Maybe being able to Parse the Module Name by either:
- taking over Attribute routing (ie, providing a custom replacement
  of the AttributeRouting based Convention)
  See: https://devblogs.microsoft.com/odata/routing-in-asp-net-core-8-0-preview/
- taking over parsing 
  something is parsing `v{version}`...maybe one could put in a {moduleName}
  somehow?

## Issues 
- Many...
- Starting with: can't figure out how to inject a custom Convention
  in order to breakpoint through and investigate AttributeRoutingConvention works
  and whether that's a viable option.
- Can't figure out how and where `v{version}` is being parsed, to see if one could
  append a custom parser.
- How that prefix could be used to help odata find the right controller.
- Although one can put routes on a controller...it causes Queryability 
  to stop working. So that's useless really.


## References 

There is a *tremendous amount of OLD documentation still around on the net.
The only one to work with is the latest/current ones.

This explains that a lot of old routing attributes are no longer used:
- https://devblogs.microsoft.com/odata/attribute-routing-in-asp-net-core-odata-8-0-rc/

The above article also shows something about `IODataPathTemplateParser`
but I could not figure out how to make one and attach it.


Others who have run into issues:
- https://stackoverflow.com/questions/16236512/prevent-webapi-odata-controllers-names-clashing/71670182#71670182

