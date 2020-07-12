using Gateway.Domain.Dto;
using Gateway.Domain.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SaveComment(CommentSaveRequest comment)
        {
            try
            {
                var postData = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync("User", postData);

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
                    return response;
                }
                return false;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}