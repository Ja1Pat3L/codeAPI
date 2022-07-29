using System.Net.Http;

namespace FrontEnd.Helper
{
    public class codeApi
    {
        public HttpClient initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri("http://codeapi-dev.us-east-1.elasticbeanstalk.com/");
            return client;
        }
    }
}
