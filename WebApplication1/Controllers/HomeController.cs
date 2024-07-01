using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RitualServer.Model;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Models.APIModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly ApiClient _apiClient = new ApiClient();

        public HomeController()
        {
            
        }
        public async Task<IActionResult> Productss()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getProducts");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Product>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> RitualAgents()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getArticle");

            if (response.IsSuccessStatusCode)
            {
                var usersList = await response.Content.ReadFromJsonAsync<List<RitualServer.Model.User>>();
                response.EnsureSuccessStatusCode();
                List<RitualServer.Model.User> users = usersList.Where(x=>x.RoleId==2).ToList();
                return View(users);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public IActionResult AboutCompany()
        {
            return View();
        }
        public IActionResult ActionsWhen()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Services()
        {
            return View();
        }
        public IActionResult Reviews()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }

    }


}
