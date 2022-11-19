using Microsoft.VisualBasic;
using Spikes.AspNetCore.ODataRouting.Models;
using Spikes.AspNetCore.ODataRouting.Models.ModuleA;
using Spikes.AspNetCore.ODataRouting.Models.ModuleB;
using System;

namespace Spikes.AspNetCore.ODataRouting.FakeDataBuilders
{
    public static class FakeDataBuilderB
    {
        private static readonly string[] Names = new[]
        {
        "Cats", "Dogs", "Fish", "Birds","Whales","Insects","Extra Terrestrials", "Plants","Microbes"
    };

        private readonly static ICollection<SomePluginModel> _data; 
        static FakeDataBuilderB()
        {
            _data =
                Enumerable.Range(1, 5).Select(index =>
                    new SomePluginModel
                    {
                        Id = index,
                        Name = Names[Random.Shared.Next(Names.Length)]
                    })
            .ToArray();

            var x = FakeDataBuilderA.Get().ToArray();
            foreach (var item in _data)
            {

                item.SubChildren = 
                Enumerable.Range(1, 2)
                    .Select(i2 =>
                                x[Random.Shared.Next(x.Length)])
                    .ToList();
            }

        }

        public static IEnumerable<SomePluginModel> Get()
        {

            return _data;
        }
    }
}
