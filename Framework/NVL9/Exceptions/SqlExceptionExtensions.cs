// <copyright file="SqlExceptionExtensions.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:22 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Exceptions
{
    using System.Data.SqlClient;
    using Models;
    using Newtonsoft.Json;

    public static class SqlExceptionExtensions
    {
        public static ExceptionModel GetExceptionModel(this SqlException exception)
        {
            // ** Init
            var result = new ExceptionModel { Code = DtoMessageCodes.SqlCritical };

            if (SqlException30000Model.Is30000Exception(exception.Message))
            {
                result = Handle30000(exception.Message, exception);
            }
            else
            {
                result.DtoMessage = $"Database Error: {exception.Message}";
            }

            // ** Return result
            return result;
        }

        public static ExceptionModel Handle30000(string message, SqlException exception)
        {
            // ** Init
            ExceptionModel result;
            var data = JsonConvert.DeserializeObject<SqlException30000Model>(message, Helpers.Serialization.GetJsonSettings());

            if (data.ERROR_PROCEDURE.Equals("GEN.spExceptionsThrown"))
            {
                var message1 = CleanMessage(data.ERROR_MESSAGE);
                data = JsonConvert.DeserializeObject<SqlException30000Model>(message1, Helpers.Serialization.GetJsonSettings());
                result = new ExceptionModel(data) { SendSlack = true };
                return result;
            }

            result = new ExceptionModel(data);
            var msgArray = data.ERROR_MESSAGE.Split(':');

            // ** Find the error Code
            if (msgArray.Length == 1)
            {
                result.DtoMessage = CleanMessage(msgArray[0]);
                return result;
            }
            switch (msgArray[0])
            {
                case "[30050]":
                    result.Code = DtoMessageCodes.SqlSecurityViolation;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30100]":
                    result.Code = DtoMessageCodes.SqlGenericNotFound;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30200]":
                    result.Code = DtoMessageCodes.SqlSprocExistingUser;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30300]":
                    result.Code = DtoMessageCodes.SqlSprocFailedToExecute;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30400]":
                    result.Code = DtoMessageCodes.SqlSprocNotImplemented;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30500]":
                    result.Code = DtoMessageCodes.SqlDataValidationInfo;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30510]":
                    result.Code = DtoMessageCodes.SqlDataValidationWarning;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;
                case "[30520]":
                    result.Code = DtoMessageCodes.SqlDataValidationCritical;
                    result.DtoMessage = CleanMessage(msgArray[1]);
                    break;

                default:
                    return result;
            }

            // ** Return result
            return result;
        }

        private static string CleanMessage(string msg)
        {
            var result = msg.Replace("[doubleQuote]", "\"");

            return result.Replace("[colon]", ":");
        }
    }
}