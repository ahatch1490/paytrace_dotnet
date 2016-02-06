using System;
using System.Net;
namespace PayTraceSDK
{
    public interface IAuthConfiguration
    {
         WebResponse SendRequest(object obj, string url);
    }
}
