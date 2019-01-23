// <copyright file="ReportSystemErrorDto.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:21 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Exceptions.Models
{
    using System;
    using System.Configuration;

    /// <summary>
    /// This class is used when trying to submit a DTO error via Slack GenericSystemError
    /// </summary>
    public class ReportSystemErrorDto
    {
        public ReportSystemErrorDto()
        {
            SlackWebHook = ConfigurationManager.AppSettings["ReportSystemError:SlackWebHook"];
            SlackChannel = ConfigurationManager.AppSettings["ReportSystemError:SlackChannel"];
        }

        public string SlackWebHook { get; set; }

        public string SlackChannel { get; set; }

        public Guid ContextUserId { get; set; }

        public string ContextUserName { get; set; }

        public int DealerId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DtoMessageCodes Code { get; set; }

        public string Message { get; set; }

        public string Stack { get; set; }

    }
}