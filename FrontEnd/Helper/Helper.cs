using System.Net.Http;

namespace FrontEnd.Helper
{
    public class codeApi
    {
        public HttpClient initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:26044");
            return client;
        }
    }
}
