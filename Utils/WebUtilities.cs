using System.Net;

namespace MyCovidApp_core.Utils
{
    public static class WebUtilities
    {
        public static HttpWebResponse getHttpResponse(string url) {
            try {
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
                return (HttpWebResponse) req.GetResponse();
            } catch (WebException ex) {
                throw new WebException("File not found\n" + ex.Message);
            }
        }
    }
}