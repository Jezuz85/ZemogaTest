using Gateway.Domain.Dto;
using Gateway.Domain.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Infrastructure.Services
{
    public class WritterService : IWritterService
    {
        private HttpClient _httpClient;

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        public async Task<User> AutenticateUser(UserLoginRequest user)
        {
            try
            {
                var postData = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await _httpClient.PostAsync("Writter", postData);
                var result2 = result.Content.ReadAsStringAsync().Result;

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<User>(result2);
                    return response;
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreatePost(CreatePostRequest post)
        {
            try
            {
                var postData = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync("Post", postData);

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