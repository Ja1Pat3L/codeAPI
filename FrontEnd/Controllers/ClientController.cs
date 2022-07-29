using FrontEnd.Helper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class ClientController : Controller
    {
        int clientId;
        codeApi _api = new codeApi();
        public async Task<IActionResult> Index()
        {
            List<Client> clients = new List<Client>();
            HttpClient client = _api.initial();
            HttpResponseMessage response = await client.GetAsync("/api/clients");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<List<Client>>(result);
            }
            return View(clients);
        }
        [HttpGet]
        public async Task<IActionResult> GetClientById(int id)
        {

            Client clients = new Client();
            HttpClient client = _api.initial();
            HttpResponseMessage response = await client.GetAsync("/api/Client/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<Client>(result);
            }
            return View(clients);
        }



        [HttpGet]

        public async Task<IActionResult> CreateClient()
        {

            return View();
        }

        [HttpPost]
            public async Task<IActionResult> CreateClient(Client myClient)
        {
            StringContent content=new StringContent(JsonConvert.SerializeObject(myClient),Encoding.UTF8,"application/json");
            Client clients = new Client();
            using (HttpClient client = _api.initial())
            {
                HttpResponseMessage response = await client.PostAsync("/api/newClient",content);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    clients = JsonConvert.DeserializeObject<Client>(result);
                }
            }

            
         
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateClient(int id)
        {
            clientId = id;
            Client clients = new Client();
            HttpClient client = _api.initial();
            HttpResponseMessage response = await client.GetAsync("/api/Client/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<Client>(result);
            }

            return View(clients);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(Client myClient)
        {

            StringContent content = new StringContent(JsonConvert.SerializeObject(myClient), Encoding.UTF8, "application/json");
            Client clients = new Client();
            using (HttpClient client = _api.initial())
            {
                HttpResponseMessage response = await client.PutAsync("/api/Client/"+ myClient.ClientId+"/updateclient" , content);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    clients = JsonConvert.DeserializeObject<Client>(result);
                }
            }



            return RedirectToAction("Index");
        }

    }
}
