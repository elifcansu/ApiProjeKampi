using ApiProjeKampi.WebUI.Dtos.CategoryDtos;
using ApiProjeKampi.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory; // HttpClient üretmek için kullanılır

        public _DefaultMenuCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; // DI ile gelen HttpClientFactory'yi sakla
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // Yeni bir HttpClient oluştur
            var responseMessage = await client.GetAsync("https://localhost:7195/api/Categories/"); // API'den kategori verilerini çek

            if (responseMessage.IsSuccessStatusCode) // Eğer API çağrısı başarılıysa
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Gelen içeriği JSON string olarak al
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); // JSON verisini listeye dönüştür
                return View(values); // View'e kategori listesini gönder
            }

            return View(); // API başarısızsa boş view döndür
        }
    }

}
