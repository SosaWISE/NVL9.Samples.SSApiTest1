// <copyright file="MyServices.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-9:11 AM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Samples.SSApiTest1.ServiceInterface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Facade;
    using Models.Facade;
    using ServiceModel;
    using ServiceStack;
    using PhysicianSearchResponse = ServiceModel.PhysicianSearchResponse;

    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse {Result = $"Hello, {request.Name}!"};
        }

        public async Task<DtoModel<List<PhysicianSearchResponse>>> Post(PhysicianSearch request)
        {
            // ** Init
            var facade = new PhysicianSearchFacade();
            var result =
                new DtoModel<List<PhysicianSearchResponse>>(DtoMessageCodes.GeneralInitializing, contextName: "Post");

            // ** Execute
            var requestInput = new PhysicianSearchRequest().PopulateWith(request);
            var responseDto = await facade.Search(requestInput);

            // ** Check result
            if (responseDto.Code != DtoMessageCodes.Success) return result.ReBaseResult(responseDto);

            // ** Get values
            var resultList = new List<PhysicianSearchResponse>();
            foreach (var physicianSearchResponse in responseDto.Value)
            {
                resultList.Add(physicianSearchResponse.ConvertTo<PhysicianSearchResponse>());
            }
            result.Success(resultList);

            // ** Return result
            return result;
        }
    }
}