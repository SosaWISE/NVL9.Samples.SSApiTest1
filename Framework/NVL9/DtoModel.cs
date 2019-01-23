// <copyright file="Class1.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-3:20 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9
{
    using System;
    using System.Data.Entity.Core;
    using System.Data.Entity.Validation;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Exceptions.Models;
    using NLog;

    public class DtoModel<T> : IDtoModel
    {
        private readonly ILogger _log = LogManager.GetCurrentClassLogger();

        public DtoModel(DtoMessageCodes code)
        {
            DtoMessage = $"|=>INITIALIZING ({Thread.CurrentThread.ManagedThreadId}) ...";
            Code = code;
            Value = default(T);
            SlackNotify = false;

            _log.Info(DtoMessage);
        }

        public DtoModel(DtoMessageCodes code, string message)
        {
            DtoMessage = message;
            Code = code;
            Value = default(T);
            SlackNotify = false;

            SaveContextNameIfExists();
            _log.Info(string.IsNullOrEmpty(ContextName)
                ? DtoMessage
                : $"|=>INITIALIZING ({Thread.CurrentThread.ManagedThreadId}) {ContextName}...");
        }

        public DtoModel(DtoMessageCodes code, string message = null, string contextName = null)
        {
            DtoMessage = message;
            ContextName = contextName;
            Code = code;
            SlackNotify = false;

            _log.Info(string.IsNullOrEmpty(ContextName)
                ? DtoMessage
                : $"|=>INITIALIZING ({Thread.CurrentThread.ManagedThreadId}) {ContextName}...");
        }

        public DtoModel(DtoMessageCodes code, T value, string message = null, string contextName = null)
        {
            DtoMessage = message;
            ContextName = contextName;
            Code = code;
            Value = value;
            SlackNotify = false;

            _log.Info(string.IsNullOrEmpty(ContextName)
                ? DtoMessage
                : $"|=>INITIALIZING ({Thread.CurrentThread.ManagedThreadId}) {ContextName}...");

            ObjectSignature = typeof(T).FullName;
        }

        private const string CONTEXT_NAME_TOKEN = "@ContextName:";

        // ReSharper disable once StaticMemberInGenericType
        private static int ContextNameLength { get; } = CONTEXT_NAME_TOKEN.Length;

        private string _originalMessage;

        public string DtoMessage { get; set; }

        public DtoMessageCodes Code { get; set; }

        public string ObjectSignature { get; private set; }

        public string RawJson { get; set; }

        public bool SlackNotify { get; private set; }

        public string ContextName { get; private set; }

        public T Value { get; set; }

        public DtoModel<T> ReBaseResult(IDtoModel newModel)
        {
            Code = newModel.Code;
            DtoMessage = newModel.DtoMessage;
            RawJson = newModel.RawJson;
            if (Value == null)
            {
                ObjectSignature = newModel.ObjectSignature;
            }

            return this;
        }

        public DtoModel<T> CaptureException(Exception ex, Func<ReportSystemErrorDto, Task<bool>> reportError = null)
        {
            // ** Init
            var result = CaptureException(DtoMessageCodes.GeneralCritical, ex);

            // ** Check if we need to send a slack notification
            if (result.SlackNotify && reportError != null)
            {
                var arg = new ReportSystemErrorDto
                {
                    Code = result.Code,
                    Message = DtoMessage,
                    Title = "DtoModel Capture Exception",
                    Text = _originalMessage,
                    Stack = Environment.StackTrace
                };
                reportError(arg);
            }

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info(
                    $"|=> CaptureException {ContextName} ({Thread.CurrentThread.ManagedThreadId}) {ContextName}: {DtoMessage}");

            // ** Return result
            return result;
        }


        public DtoModel<T> CaptureException(DtoMessageCodes code, Exception ex)
        {
            // ** Check if this is a SqlException
            if (ex is SqlException eSql) return CaptureException(eSql);

            // ** Init
            var message = ParseException(ex, out var exceptionType);
            DtoMessage = $"Exception{exceptionType} thrown: {message}";
            Code = code;
            Value = default(T);

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info(
                    $"|=> CaptureException {ContextName} ({Thread.CurrentThread.ManagedThreadId}) {ContextName}: {message}");
            _log.Error(ex, $"DtoMessage: {DtoMessage}");

            return this;
        }

        public DtoModel<T> CaptureException(SqlException ex)
        {
            var message = ex.GetExceptionModel();
            DtoMessage = $"{message.DtoMessage}";
            Code = message.Code;
            SlackNotify = message.SendSlack;
            _originalMessage = message.OriginalMessage;
            Value = default(T);

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info($"|=> CaptureException ({Thread.CurrentThread.ManagedThreadId}) {ContextName}: {message}");

            return this;
        }

        public DtoModel<T> ReBaseResult(DtoMessageCodes code, string message)
        {
            DtoMessage = message;
            Code = code;
            Value = default(T);

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info($"|=>ERROR (ReBasing) ({Thread.CurrentThread.ManagedThreadId}) {ContextName}: {message}");

            return this;
        }

        public DtoModel<T> ReBaseResult(DtoMessageCodes code, string message, T value)
        {
            DtoMessage = message;
            Code = code;
            Value = value;

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info($"|=>ERROR (ReBasing) ({Thread.CurrentThread.ManagedThreadId}) {ContextName}: {message}");

            ObjectSignature = typeof(T).FullName;

            return this;
        }

        public DtoModel<T> Success(T value)
        {
            Code = DtoMessageCodes.Success;
            DtoMessage = "Success";
            Value = value;

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info($"|=>SUCCESS ({Thread.CurrentThread.ManagedThreadId}) {ContextName}");

            return this;
        }

        public void Success(T value, string message)
        {
            Code = DtoMessageCodes.Success;
            DtoMessage = message;
            Value = value;

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info($"|=>SUCCESS ({Thread.CurrentThread.ManagedThreadId}) {ContextName}: {message}");
        }

        public void Success(T value, string message, string rawJson)
        {
            Code = DtoMessageCodes.Success;
            DtoMessage = message;
            RawJson = rawJson;
            Value = value;

            if (!string.IsNullOrEmpty(ContextName))
                _log.Info($"|=>SUCCESS ({Thread.CurrentThread.ManagedThreadId}) {ContextName}");
        }

        public DtoModel<T> CaptureException(SelectHealthBaseException ex)
        {
            Code = ex.Code;
            DtoMessage = ex.Message;

            _log.Error(ex,
                string.IsNullOrEmpty(ContextName)
                    ? $"DtoMessage: {DtoMessage}"
                    : $"ContextName: {ContextName} | DtoMessage: {DtoMessage}");

            return this;
        }

        public string ParseException(Exception e, out string exceptionType)
        {
            exceptionType = string.Empty;

            if (e is DbEntityValidationException eV)
            {
                exceptionType = " of 'DbEntityValidationException' type";
                return eV.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
            }

            if (e is EntityCommandExecutionException ec)
            {
                exceptionType = " of 'EntityCommandExecutionException' type";
                return (ec.Message.IndexOf("See the inner exception", StringComparison.Ordinal) >= 0 &&
                        ec.InnerException != null)
                    ? ec.InnerException.Message
                    : ec.Message;
            }

            if (e.Message.IndexOf("See the inner exception", StringComparison.Ordinal) >= 0 &&
                e.InnerException?.InnerException != null)
            {
                return e.InnerException.InnerException.Message;
            }

            if (e.Message.IndexOf("See the inner exception", StringComparison.Ordinal) >= 0 && e.InnerException != null)
            {
                return e.InnerException.Message;
            }

            return e.Message;
        }

        private void SaveContextNameIfExists()
        {
            // ** Init
            Regex regex = new Regex(CONTEXT_NAME_TOKEN);
            Match match = regex.Match(DtoMessage);
            if (match.Success)
            {
                var result = DtoMessage.Substring(ContextNameLength);
                ContextName = result;
            }
        }
    }
}