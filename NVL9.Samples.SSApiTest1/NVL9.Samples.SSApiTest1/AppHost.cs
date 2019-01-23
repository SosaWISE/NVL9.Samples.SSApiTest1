using Funq;
using ServiceStack;
using NVL9.Samples.SSApiTest1.ServiceInterface;

namespace NVL9.Samples.SSApiTest1
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptySelfHost
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("NVL9.Samples.SSApiTest1", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature(allowedHeaders: "Content-Type",
                allowCredentials: true,
                allowOriginWhitelist: new[] { "https://null.jsbin.com" }));
        }
    }
}
