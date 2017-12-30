using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FiskeFangsterClient.Model;
using Newtonsoft.Json;

namespace FiskeFangsterClient
{
    class Start
    {
        private const String serverUrl = "http://wcfresteksamen.azurewebsites.net/service1.svc/";
        private HttpClient Client = new HttpClient();


        public Start()
        {
            Client.BaseAddress = new Uri(serverUrl);
        }

        public void Menu()
        {
            while (true)
            {
                Console.Write("Menu:\r\n1. Get all catches\r\n2. Insert new\r\n3. Delete by id\r\n4. Get 1 objekt\r\nSkriv et tal: ");
                String cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        GetCatches();
                        break;
                    case "2":
                        InsertNew();
                        break;
                    case "3":
                        Console.Write("Skriv et id: ");
                        String idDelete = Console.ReadLine();
                        DeleteById(Int32.Parse(idDelete ?? throw new InvalidOperationException()));
                        break;
                    case "4":
                        Console.Write("Skriv et id: ");
                        String id = Console.ReadLine();
                        GetSpecificCatch(Int32.Parse(id ?? throw new InvalidOperationException()));
                        break;

                }
                Console.WriteLine("\r\n");
            }
        }

        public async void GetCatches()
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            String requestUrl = "change";

            try
            {
                HttpResponseMessage ResponseGetCall = Client.GetAsync(requestUrl).Result;

                if (ResponseGetCall.IsSuccessStatusCode)
                {
                    String GetCallJson = await ResponseGetCall.Content.ReadAsStringAsync();

                    List<ChangeClassName> GetAllCatches = JsonConvert.DeserializeObject<List<ChangeClassName>>(GetCallJson);

                    foreach (var obj in GetAllCatches)
                    {
                        Console.WriteLine(obj);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void GetSpecificCatch(int id)
        {
            string idSomString = id.ToString();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            String requestUrl = "change/" + idSomString;

            try
            {
                HttpResponseMessage ResponseGetSpecificCall = Client.GetAsync(requestUrl).Result;

                if (ResponseGetSpecificCall.IsSuccessStatusCode)
                {
                    String GetCallJson = await ResponseGetSpecificCall.Content.ReadAsStringAsync();

                    ChangeClassName getChangeClassName = JsonConvert.DeserializeObject<ChangeClassName>(GetCallJson);
                    Console.WriteLine(getChangeClassName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void InsertNew()
        {
            ChangeClassName tmpChangeClassName = new ChangeClassName();
            tmpChangeClassName.Id = 0;
            tmpChangeClassName.ChangeInteger = 1;
            tmpChangeClassName.ChangeDouble = 2.0;
            tmpChangeClassName.ChangeString = "navn";
            tmpChangeClassName.ChangeString1 = "mere navn";

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            String requestUrl = "change";

            try
            {
                HttpResponseMessage InsertNewCatch = await Client.PostAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(tmpChangeClassName), Encoding.UTF8, "application/json"));

                Console.WriteLine(InsertNewCatch.IsSuccessStatusCode ? "\r\nSuccess: 201" : "\r\nNoget gik galt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteById(int id)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            String requestUrl = "change/" + id;

            try
            {
                HttpResponseMessage ResponseGetSpecificCall = Client.GetAsync(requestUrl).Result;

                if (ResponseGetSpecificCall.IsSuccessStatusCode)
                {
                    HttpResponseMessage DeleteItem = Client.DeleteAsync(requestUrl).Result;

                    Console.WriteLine(DeleteItem.IsSuccessStatusCode ? $"\r\nChange med id {id} blev slettet": "\r\nNoget gik galt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
