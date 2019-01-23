// <copyright file="SqlException30000Model.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-4:26 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9.Exceptions.Models
{
    using System;
    using Newtonsoft.Json;

    public class SqlException30000Model
    {

        // ReSharper disable once InconsistentNaming
        public int ERROR_NUMBER { get; set; }

        // ReSharper disable once InconsistentNaming
        public int ERROR_SEVERITY { get; set; }

        // ReSharper disable once InconsistentNaming
        public int ERROR_STATE { get; set; }

        // ReSharper disable once InconsistentNaming
        public string ERROR_PROCEDURE { get; set; }

        // ReSharper disable once InconsistentNaming
        public int ERROR_LINE { get; set; }

        // ReSharper disable once InconsistentNaming
        public string ERROR_MESSAGE { get; set; }

        // ReSharper disable once InconsistentNaming
        public string SERVER_NAME { get; set; }

        // ReSharper disable once InconsistentNaming
        public string DB_NAME { get; set; }

        // ReSharper disable once InconsistentNaming
        public string SCHEMA_NAME { get; set; }

        // ReSharper disable once InconsistentNaming
        public string TABLE_NAME { get; set; }

        // ReSharper disable once InconsistentNaming
        public string PRIMARY_KEY { get; set; }

        public static bool Is30000Exception(string message)
        {
            return Is30000Exception(message, out _);
        }

        //** Methods
        public static bool Is30000Exception(string message, out int errorNumber)
        {
            errorNumber = -1;
            if (message.IndexOf("\"ERROR_NUMBER\":", StringComparison.Ordinal) >= 0)
            {
                var data = JsonConvert.DeserializeObject<SqlException30000Model>(message, Helpers.Serialization.GetJsonSettings());
                errorNumber = data.ERROR_NUMBER;
                return true;
            }

            return false;
        }
    }
}