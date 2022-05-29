using System.Net;

namespace SimpleRetryPattern;

public static class ExceptionExtensions
{
    public static bool IsTransient(this Exception source)
    {
        return true;
    //{
    //    var webException = source as WebException;
    //    if (webException != null)
    //    {
    //        // If the web exception contains one of the following status values
    //        // it might be transient.
    //        return new[] {WebExceptionStatus.ConnectionClosed,
    //              WebExceptionStatus.Timeout,
    //              WebExceptionStatus.RequestCanceled }.
    //                Contains(webException.Status);
    //    }

    //    // Additional exception checking logic goes here.
    //    return false;
    }
}
