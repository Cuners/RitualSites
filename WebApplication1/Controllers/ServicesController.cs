using Microsoft.AspNetCore.Mvc;
using RitualServer.Model;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.APIModels;

namespace WebApplication1.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApiClient _apiClient = new ApiClient();
        public ServicesController()
        {

        }
        public async Task<IActionResult> Services(string categoryName)
        {
            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getServices");
            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Service>>();
                response.EnsureSuccessStatusCode();
                HttpResponseMessage categoryResponse = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCategoriesServices");

                var categoriesList = await categoryResponse.Content.ReadFromJsonAsync<List<CategoiresService>>();
                categoryResponse.EnsureSuccessStatusCode();
                ViewData["Categories"] = categoriesList;
                if (categoryName != null  && categoryName!="all")
                {
                    productList = productList.Where(c => c.Category.Name==categoryName).ToList();
                }
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("ServicesListPartial", productList);
                }
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }


        }
    }
}
