using Gateway.Domain.Dto;
using Gateway.Domain.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Infrastructure.Services
{
    public class EditorService : IEditorService
    {
        private HttpClient _httpClient;

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AproveRejectPost(PostRequest post)
        {
            try
            {
                var postData = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                var result = await _httpClient.PutAsync("Editor", postData);

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

        public async Task<bool> DeletePost(PostDeleteRequest post)
        {
            try
            {
                var postData = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync("Editor", postData);

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

        public async Task<IEnumerable<Post>> GetPendingPosts()
        {
            try
            {
                var result = await _httpClient.GetAsync("Editor");
                var result2 = result.Content.ReadAsStringAsync().Result;

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<IEnumerable<Post>>(result2);
                    return response;
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}