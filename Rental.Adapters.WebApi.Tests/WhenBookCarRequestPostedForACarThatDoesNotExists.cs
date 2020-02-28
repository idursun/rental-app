using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using RentalApp.Adapters.WebApi.Models;
using Shouldly;

namespace RentalApp.Adapters.WebApi.Tests
{
    public class WhenBookCarRequestPostedForACarThatDoesNotExists : GivenBookCarController
    {
        [Test]
        public async Task it_should_return_notfound()
        {
            var message = await HttpClient.PostAsJsonAsync("/booking", new BookCarRequest());

            message.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}
