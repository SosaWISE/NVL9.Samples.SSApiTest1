// <copyright file="Serialization.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:26 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Helpers
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Serialization
    {
        public static JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}