// <copyright file="IPhysicianSearchFacade.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:18 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Business.Facade
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Facade;

    public interface IPhysicianSearchFacade
    {
        Task<DtoModel<List<PhysicianSearchResponse>>> Search(PhysicianSearchRequest request);
    }
}