using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListMobileApp1.Services
{
    public class ProfileService
    {
        private const string ApiUrl = "https://192.168.1.44:45455/api/";

        private readonly HttpClient _httpClient;

        public ProfileService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(ApiUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(400);
        }

        public async Task<User> GetUserProfile(int userId) // kullanılmıyor, main pageden userı çekiyoruz
        {
            var response = await _httpClient.GetAsync(ApiUrl + "Users/getUserById?userId=" + userId);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var userDTO = JsonConvert.DeserializeObject<User>(jsonContent);

                return userDTO;
            }
            else
            {
                // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                return null;
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync(ApiUrl + "User/update", dto);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(jsonContent);

                return userDTO;
            }
            else
            {
                // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                return null;
            }
        }

    }
}
