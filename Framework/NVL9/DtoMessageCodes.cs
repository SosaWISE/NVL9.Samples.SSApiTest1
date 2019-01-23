// <copyright file="DtoMessageCodes.cs" company="SelectHealth.org">
//     Copyright (c) 2019 SelectHealth.org.  All rights reserved.
// </copyright>
// <summary>
//     Document created on 2019-01-22-3:53 PM
// </summary>
// <author>Andres Sosa (imail2)</author>

namespace NVL9
{
    public enum DtoMessageCodes
    {
        Success = 0,
        GeneralInitializing = 1,
        GeneralWarning = 2,
        GeneralCritical = 3,
        GeneralInvalidJson = 4,

        GeneralInputValidationWarning = 10,

        //// ** CRM -- Messages
        //NoIndustryNumberPrimaryAssigned = 1010,
        //NoIndustryNumberSecondaryAssigned = 1020,
        //NoCellularVendorAccountAssigned = 1030,

        //// ** CRM -- MAS
        //MasAccountFailedToOnBoard = 2010,
        //MasAccountMoniServerException = 2015,

        // ** Facade -- Business
        FacadeInitializing = 10001,
        FacadeWarning = 10002,
        FacadeCritical = 10003,
        FacadeMessage = 10004,

        // ** DataAccess -- Repository
        DataAccessInitializing = 20001,
        DataAccessWarning = 20002,
        DataAccessCritical = 20003,
        DataAccessMessage = 20004,

        // ** SQL 
        SqlSuccess = 30000,
        SqlWarning = 30001,
        SqlCritical = 30002,
        SqlSecurityViolation = 30050,
        SqlGenericNotFound = 30100,
        SqlSprocExistingUser = 30200,
        SqlSprocFailedToExecute = 30300,
        SqlSprocNotImplemented = 30400,
        SqlSprocMissingArgument = 30410,
        SqlDataValidationInfo = 30500,
        SqlDataValidationWarning = 30510,
        SqlDataValidationCritical = 30520,

        // ** Third Party software
        ThirdPartyInitializing = 50001,
        ThirdPartyWarning = 50002,
        ThirdPartyCritical = 50003,

        // ** Payment processing
        AuthNetInitializing = 80001,
        AuthNetWarning = 80002,
        AuthNetCritical = 80003,
        AuthNetMessage = 80004,

        // ** Document Management
        //        DocuSignInitializing = 90001
    }
}