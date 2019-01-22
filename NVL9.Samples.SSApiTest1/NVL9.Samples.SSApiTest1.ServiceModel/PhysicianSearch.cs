// <copyright file="PhysicianRequest.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-2:35 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Samples.SSApiTest1.ServiceModel
{
    using ServiceStack;

    [Route("/PhysicianSearch", "POST")]
    public class PhysicianSearch : IPost, IReturn<HelloResponse>
    {
        public string[] Specialty { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int WithIn { get; set; }

        public bool AcceptingNewPatients { get; set; }

        public string[] Language { get; set; }

        public string Gender { get; set; }

        public string Clinic { get; set; }

        public string Hours { get; set; }

        public bool MyHealthRecords { get; set; }
    }

    public class PhysicianSearchResponse
    {
        public string FullName { get; set; }

        public string FullAddress { get; set; }
    }
}