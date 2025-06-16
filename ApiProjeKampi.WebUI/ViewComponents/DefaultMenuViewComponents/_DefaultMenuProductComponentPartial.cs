using ApiProjeKampi.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory; // HttpClient üretmek için kullanılır

        public _DefaultMenuProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; // DI ile gelen HttpClientFactory'yi sakla
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // Yeni bir HttpClient oluştur
            var responseMessage = await client.GetAsync("https://localhost:7195/api/Products/"); // API'den ürün verilerini çek

            if (responseMessage.IsSuccessStatusCode) // Eğer API çağrısı başarılıysa
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Gelen içeriği JSON string olarak al
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); // JSON verisini listeye dönüştür
                return View(values); // View'e kategori listesini gönder
            }

            return View(); // API başarısızsa boş view döndür
        }
    }
}
