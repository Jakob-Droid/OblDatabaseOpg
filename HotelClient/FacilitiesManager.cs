using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HotelWebService;

namespace HotelClient
{
    public class ManageFacilities
    {
        const string serverUrl = "http://localhost:58987";

        public static void ReadFacilities()
        {
            HttpClientHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<Facility> facilityList = new List<Facility>();
                try
                {
                    var response = client.GetAsync("api/facilities").Result;
                    var facility = response.Content.ReadAsAsync<IEnumerable<Facility>>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var item in facility)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public static void CreateFacility(Facility facility)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PostAsJsonAsync("api/facilities", facility).Result;
                    Console.WriteLine("----- New Facility Created -----");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void DeleteFacility(int id)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.DeleteAsync($"api/facilities/" + id).Result;
                    Console.WriteLine("----- Facility Removed -----");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void UpdateFacilityName(int selectedFacilityId, string updatedName)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PutAsJsonAsync("api/facilities/" + selectedFacilityId, new Facility()
                            {Facility_No = selectedFacilityId, Name = updatedName})
                        .Result; //Denne løsning er bedst når Facility kun har en attribut.
                    Console.WriteLine("----- Facility Updated -----");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
