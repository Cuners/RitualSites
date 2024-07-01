using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RitualServer.Model;
using System.Diagnostics;
using System.Net;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Models.APIModels;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApiClient _apiClient = new ApiClient();
        public ProductsController()
        {

        }
        public async Task<IActionResult> Categories()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCategories");
            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Category>>();
                response.EnsureSuccessStatusCode();
                var categorydto=productList.Select(c=> new CategoryDTO
                {
                    Name = c.Name,
                    Image = c.Image,
                    Controller = CategoryMapping.Mappings[c.Name].Controller,
                    Action = CategoryMapping.Mappings[c.Name].Action
                }).ToList();
                // Обработка данных, полученных от сервера WebApi
                return View(categorydto);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }


        }
        public async Task<IActionResult> Clothes(double? minPrice, double? maxPrice, List<string> colorFilter, List<string> materialFilter)
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getClothes");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Clothe>>();
                response.EnsureSuccessStatusCode();
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    productList = productList.Where(c => c.Product.Price >= minPrice.Value && c.Product.Price <= maxPrice.Value).ToList();
                }
                if (colorFilter != null && colorFilter.Any())
                {
                    productList = productList.Where(c => colorFilter.Contains(c.Color.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (materialFilter != null && materialFilter.Any())
                {
                    productList = productList.Where(c => materialFilter.Contains(c.Material.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("ClothListPartial", productList);
                }
                return View(productList);
            }
            else
            {
                // Handle error
                return View("Error");
            }
        }
        public async Task<IActionResult> Coffins(double? minPrice, double? maxPrice, List<string> colorFilter, List<string> materialFilter)
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCoffins");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Coffin>>();
                response.EnsureSuccessStatusCode();
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    productList = productList.Where(c => c.Product.Price >= minPrice.Value && c.Product.Price <= maxPrice.Value).ToList();
                }
                if (colorFilter != null && colorFilter.Any())
                {
                    productList = productList.Where(c => colorFilter.Contains(c.Color.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (materialFilter != null && materialFilter.Any())
                {
                    productList = productList.Where(c => materialFilter.Contains(c.Material.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("CoffinListPartial", productList);
                }
                return View(productList);
            }
            else
            {
                // Handle error
                return View("Error");
            }
        }
        public async Task<IActionResult> Crosses(double? minPrice, double? maxPrice, List<string> colorFilter, List<string> materialFilter)
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCrosses");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Cross>>();
                response.EnsureSuccessStatusCode();
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    productList = productList.Where(c => c.Product.Price >= minPrice.Value && c.Product.Price <= maxPrice.Value).ToList();
                }
                if (colorFilter != null && colorFilter.Any())
                {
                    productList = productList.Where(c => colorFilter.Contains(c.Color.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (materialFilter != null && materialFilter.Any())
                {
                    productList = productList.Where(c => materialFilter.Contains(c.Material.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("CrossListPartial", productList);
                }
                return View(productList);
            }
            else
            {
                // Handle error
                return View("Error");
            }
        }
        public async Task<IActionResult> Monuments(double? minPrice, double? maxPrice, List<string> colorFilter, List<string> materialFilter)
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getMonuments");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Monument>>();
                response.EnsureSuccessStatusCode();
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    productList = productList.Where(c => c.Product.Price >= minPrice.Value && c.Product.Price <= maxPrice.Value).ToList();
                }
                if (colorFilter != null && colorFilter.Any())
                {
                    productList = productList.Where(c => colorFilter.Contains(c.Color.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (materialFilter != null && materialFilter.Any())
                {
                    productList = productList.Where(c => materialFilter.Contains(c.Material.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("MonumentListPartial", productList);
                }
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Tapes(double? minPrice, double? maxPrice, List<string> colorFilter, List<string> materialFilter)
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getTapes");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Tape>>();
                response.EnsureSuccessStatusCode();
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    productList = productList.Where(c => c.Product.Price >= minPrice.Value && c.Product.Price <= maxPrice.Value).ToList();
                }
                if (colorFilter != null && colorFilter.Any())
                {
                    productList = productList.Where(c => colorFilter.Contains(c.Color.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (materialFilter != null && materialFilter.Any())
                {
                    productList = productList.Where(c => materialFilter.Contains(c.Material.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("TapeListPartial", productList);
                }
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Urns(double? minPrice, double? maxPrice, List<string> colorFilter, List<string> materialFilter)
        {
            try
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getUrns");

                if (response.IsSuccessStatusCode)
                {
                    var productList = await response.Content.ReadFromJsonAsync<List<Urn>>();
                    response.EnsureSuccessStatusCode();
                    if (minPrice.HasValue && maxPrice.HasValue)
                    {
                        productList = productList.Where(c => c.Product.Price >= minPrice.Value && c.Product.Price <= maxPrice.Value).ToList();
                    }
                    if (colorFilter != null && colorFilter.Any())
                    {
                        productList = productList.Where(c => colorFilter.Contains(c.Color.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                    }
                    if (materialFilter != null && materialFilter.Any())
                    {
                        productList = productList.Where(c => materialFilter.Contains(c.Material.Name, StringComparer.OrdinalIgnoreCase)).ToList();
                    }
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return PartialView("UrnListPartial", productList);
                    }
                    return View(productList);
                }
                else
                {
                    // Обработка ошибки
                    return View("Error");
                }
            }
            catch
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        public async Task<IActionResult> InfoCoffin(int? id)
        {
            if (id != null && id >= 0)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Coffin/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Coffin>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoCloth(int? id)
        {
            if (id != null && id >= 0)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Cloth/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Clothe>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoUrn(int? id)
        {
            if (id != null && id >= 0)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Urn/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Urn>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoTape(int? id)
        {
            if (id != null && id >= 0)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Tape/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Tape>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoMonument(int? id)
        {
            if (id != null && id >= 0)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Monument/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Monument>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoCross(int? id)
        {
            if (id != null && id >= 0)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Cross/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Cross>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Shipment shipment)
        {
            try
            {
                if (shipment == null)
                {
                    ModelState.AddModelError("Shipment", "Данные отправки недопустимы");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var clientName = Request.Form["UserName"];
                var clientEmail = Request.Form["UserEmail"];
                var clientPhone = Request.Form["UserPhone"];
                var client = await FindClient(clientName, clientEmail, clientPhone);
                if (client == null)
                {
                    // Создаем клиента, если его нет
                    client = new Client
                    {
                        FIO = clientName,
                        Email = clientEmail,
                        Telephone = clientPhone
                    };
                    client.ClientId = await CreateClient(client);
                }
                
                int productId = int.Parse(Request.Form["productId"]);
                var orderId = await CreateNewOrder();
                await CreateOrderItem(orderId, productId);
                await CreateShipment(shipment, orderId);
                await CreateClientOrder(orderId, client.ClientId);
                TempData["SuccessMessage"] = "Заказ успешно создан!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return Content($"Произошла ошибка: {ex.Message}");
            }
        }
        private async Task<Client> FindClient(string name, string email, string phone)
        {
            var queryString = $"search?name={WebUtility.UrlEncode(name)}&email={WebUtility.UrlEncode(email)}&phone={WebUtility.UrlEncode(phone)}";
            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Client/{queryString}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(responseBody);
            }

            return null;
        }
        private async Task<int> CreateClient(Client client)
        {
            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Client",
                new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var createdClient = JsonConvert.DeserializeObject<Client>(responseBody);
            return createdClient.ClientId;
        }
        private async Task<int> CreateNewOrder()
        {
            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                StatusId = 1
            };

            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Order",
                new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<Order>(responseBody);
            return createdProduct.OrderId;
        }

        private async Task CreateOrderItem(int orderId, int productId)
        {
            OrderItem orderItem = new OrderItem()
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = 1
            };

            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/OrderItem",
                new StringContent(JsonConvert.SerializeObject(orderItem), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        private async Task CreateShipment(Shipment shipment, int orderid)
        {
            shipment.OrderId = orderid;
            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Shipment",
                new StringContent(JsonConvert.SerializeObject(shipment), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        private async Task CreateClientOrder(int orderId, int clientID)
        {
            ClientOrder orderItem = new ClientOrder()
            {
                ClientID = clientID,
                OrderID = orderId,
            };

            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/ClientOrder",
                new StringContent(JsonConvert.SerializeObject(orderItem), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }

}
