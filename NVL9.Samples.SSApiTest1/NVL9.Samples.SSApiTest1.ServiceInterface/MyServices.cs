using ServiceStack;
using NVL9.Samples.SSApiTest1.ServiceModel;

namespace NVL9.Samples.SSApiTest1.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}