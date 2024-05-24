using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;


namespace Utils
{
    public class HttpRequest
    {
        private readonly HttpClient _client;

        public HttpRequest()
        {
            _client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null)
        {
            AddHeaders(headers);
            var response = await _client.GetAsync(url);
            return await HandleResponse<T>(response);
        }

        public async Task<T> PostAsync<T>(string url, object data, IDictionary<string, string> headers = null)
        {
            AddHeaders(headers);
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);
            return await HandleResponse<T>(response);
        }

        public async Task<byte[]> DownloadImageAsync(string imageUrl, IDictionary<string, string> headers = null)
        {
            AddHeaders(headers);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsByteArrayAsync();
            }
        }

        public async Task<string> DownloadImageAsBase64Async(string imageUrl, IDictionary<string, string> headers = null)
        {
            AddHeaders(headers);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode();
                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }


        private void AddHeaders(IDictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            else
            {
                _client.DefaultRequestHeaders.Clear();
            }
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed with status code: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
