using Spikes.AspNetCore.ODataRouting.Models;

namespace Spikes.AspNetCore.ODataRouting.Singleton
{
    public static class FakeDataBuilder
    {
        private static readonly string[] Names = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public static IEnumerable<SomeModel> Get()
        {

            return Enumerable.Range(1, 5).Select(index => 
            new SomeModel
            { Id=index, 
              Name = Names[Random.Shared.Next(Names.Length)]
            })
.ToArray();

        }
    }
}
