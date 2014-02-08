using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrankyJanes.WebUI.Logger
{
    #region Enumerated Codes
    public enum LogLevel
    {
        Error,
        Warning,
        Information,
        Debug
    }

    public enum HTTPCode
    {
        Continue = 100,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultipleChoices = 300,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        //ReservedForLaterUse = 306,
        TemporaryRedirect = 307,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestURITooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HTTPVersionNotSupported = 505
    }

    #endregion


    public class Event
    {
        public DateTime timeStamp;
        public int statusCode; //HTTP status code
        public int subCode; // Custom Sub-Code
        public string statusDetail; // Description of status
        public string subDetail; //Desription of subCode
        public string message; // Message suitable end-users
        public string developerMessage; // Message for developers
        public string moreInfo; // URL to help/documentation page
        public LogLevel level;


        Event(int _statusCode, int _subCode, string _message, string _developerMessage, LogLevel logLevel)
        {
            statusCode = _statusCode;
            subCode = _subCode;
            timeStamp = DateTime.Now;
            level = logLevel;
            //TODO: Logic that populate status and sub detail strings
            message = _message;
            developerMessage = _developerMessage;
            //TODO: Generate URL using status and subCode to link documentation
        }
    }
}