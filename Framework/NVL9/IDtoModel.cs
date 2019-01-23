// <copyright file="IDtoModel.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:15 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9
{
    public interface IDtoModel
    {
        string DtoMessage { get; set; }

        DtoMessageCodes Code { get; set; }

        string ObjectSignature { get; }

        string RawJson { get; set; }
    }
}