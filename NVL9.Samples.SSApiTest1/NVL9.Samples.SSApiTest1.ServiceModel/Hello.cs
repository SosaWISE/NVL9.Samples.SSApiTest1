// <copyright file="Hello.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-9:11 AM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Samples.SSApiTest1.ServiceModel
{
    using ServiceStack;

    [Route("/hello/{Name}", "POST,GET")]
    public class Hello : IPost, IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }
}