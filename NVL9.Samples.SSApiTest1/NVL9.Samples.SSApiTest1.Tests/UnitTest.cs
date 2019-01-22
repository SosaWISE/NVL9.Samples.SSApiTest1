using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using NVL9.Samples.SSApiTest1.ServiceInterface;
using NVL9.Samples.SSApiTest1.ServiceModel;

namespace NVL9.Samples.SSApiTest1.Tests
{
    public class UnitTest
    {
        private readonly ServiceStackHost appHost;

        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<MyServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        [Test]
        public void Can_call_MyServices()
        {
            var service = appHost.Container.Resolve<MyServices>();

            var response = (HelloResponse)service.Any(new Hello { Name = "World" });

            Assert.That(response.Result, Is.EqualTo("Hello, World!"));
        }

        [Test]
        public void PhysicianSearchTest()
        {
            var service = appHost.Container.Resolve<MyServices>();

            var response = service.Post(new PhysicianSearch
            {
                City = "Murray UTAH",
                Gender = "Some Doctor"
            });

            Assert.That(response.FullAddress, Is.EqualTo("Murray UTAH"));
        }
    }
}
