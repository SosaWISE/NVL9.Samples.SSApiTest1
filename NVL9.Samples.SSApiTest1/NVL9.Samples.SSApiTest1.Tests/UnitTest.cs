// <copyright file="UnitTest.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-9:11 AM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Samples.SSApiTest1.Tests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using ServiceInterface;
    using ServiceModel;
    using ServiceStack;
    using ServiceStack.Testing;

    public class UnitTest
    {
        private readonly ServiceStackHost _appHost;

        public UnitTest()
        {
            _appHost = new BasicAppHost().Init();
            _appHost.Container.AddTransient<MyServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _appHost.Dispose();
        }

        [Test]
        public void Can_call_MyServices()
        {
            var service = _appHost.Container.Resolve<MyServices>();

            var response = (HelloResponse) service.Any(new Hello {Name = "World"});

            Assert.That(response.Result, Is.EqualTo("Hello, World!"));
        }

        [Test]
        public async Task PhysicianSearchTest()
        {
            var service = _appHost.Container.Resolve<MyServices>();

            PhysicianSearch request = new PhysicianSearch
            {
                City = "Murray UTAH",
                Gender = "Some Doctor"
            };
            var responseDto = await service.Post(request);

            Assert.AreEqual(responseDto.Code, DtoMessageCodes.Success);

            Assert.That(responseDto.Value.Count, Is.EqualTo(1));

            Assert.That(responseDto.Value[0].FullAddress, Is.EqualTo("Murray UTAH"));
        }
    }
}