// <copyright file="PhysicianSearchRequest.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-3:22 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Models.Facade
{
    public class PhysicianSearchRequest
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
}