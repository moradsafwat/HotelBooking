using HotelBooking.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelBooking.Web.Controllers
{
    public class BranchController : Controller
    {
        //Hosted web API REST Service base url
        string baseUri = "https://localhost:44391/api/";
        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            IEnumerable<BranchDto> branchsView = null;

            //Passing service base url
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllBranchs using HttpClient
            HttpResponseMessage res = await client.GetAsync("Branch/GetAllBranchs");
            //Checking the response is successful or not which is sent using HttpClient
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                string branchRes = await res.Content.ReadAsStringAsync();
                //Deserializing the response recieved from web api and storing into the Branchs IEnumerable
                branchsView = JsonConvert.DeserializeObject<IEnumerable<BranchDto>>(branchRes);

                return View(branchsView);
            }
            else
            {
                return View(branchsView = null);
            }

        }
        public async Task<IActionResult> Branch(int id)
        {
            IEnumerable<RoomDto> branchRoomView = null;

            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaion/json"));

            HttpResponseMessage res = await client.GetAsync($"Room/GetRoomsByBranchId?branchId={id}");

            if (res.IsSuccessStatusCode)
            {
                string branchRes = await res.Content.ReadAsStringAsync();
                branchRoomView = JsonConvert.DeserializeObject<IEnumerable<RoomDto>>(branchRes);

                return View(branchRoomView);
            }
            else
            {
                return View();
            }
        }
    }
}
