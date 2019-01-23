// <copyright file="SelectHealthBaseException.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:28 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Exceptions
{
    using System;

    public class SelectHealthBaseException : Exception
    {
        public SelectHealthBaseException(DtoMessageCodes code, string message) : base(message)
        {
            Code = code;
        }

        public DtoMessageCodes Code { get; }
    }
}