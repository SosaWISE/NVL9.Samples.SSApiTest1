// <copyright file="ExceptionModel.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:25 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Exceptions.Models
{
    using System.Data.SqlClient;

    public class ExceptionModel
    {
        public ExceptionModel()
        {
            SendSlack = false;
        }

        public ExceptionModel(SqlException30000Model data) : this()
        {
            Code = AssignCode(data.ERROR_NUMBER);
            OriginalMessage = data.ERROR_MESSAGE;
            DtoMessage = AssignMessage(data.ERROR_NUMBER, data.ERROR_MESSAGE);
        }

        public ExceptionModel(SqlException exception) : this()
        {
            Code = AssignCode(exception.ErrorCode);
            OriginalMessage = exception.Message;
            DtoMessage = AssignMessage(exception.ErrorCode, exception.Message);
        }

        public DtoMessageCodes Code { get; set; }

        public string DtoMessage { get; set; }

        public string OriginalMessage { get; set; }

        public bool SendSlack { get; set; }

        private DtoMessageCodes AssignCode(int errorNumber)
        {
            switch (errorNumber)
            {
                case 30050:
                    return DtoMessageCodes.SqlSecurityViolation;
                case 30100:
                    return DtoMessageCodes.SqlGenericNotFound;
                case 30200:
                    return DtoMessageCodes.SqlSprocExistingUser;
                default:
                    return DtoMessageCodes.SqlCritical;
            }
        }

        private string AssignMessage(int errorNumber, string message)
        {
            switch (errorNumber)
            {
                case 547:
                    SendSlack = true;
                    return "There is some meta data missing.  Please contact administrator.";
            }

            // ** Return result
            return message;
        }
    }
}