// <copyright file="PhysicianSearchFacade.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-3:19 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Business.Facade
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Facade;

    public class PhysicianSearchFacade : IPhysicianSearchFacade
    {
        public async Task<DtoModel<List<PhysicianSearchResponse>>> Search(PhysicianSearchRequest request)
        {
            // ** Init
            var result = new DtoModel<List<PhysicianSearchResponse>>(DtoMessageCodes.FacadeInitializing, "Search");

            try
            {
                var resultValue = new List<PhysicianSearchResponse>();
                var task = Task.Run(() =>
                {
                    resultValue.Add(new PhysicianSearchResponse
                    {
                        FullAddress = request.City,
                        FullName = request.ZipCode
                    });
                });
                await task;

                // ** Flag success
                result.Success(resultValue);
            }
            catch (Exception e)
            {
                result.CaptureException(e);
            }

            // ** Return result
            return result;
        }
    }
}