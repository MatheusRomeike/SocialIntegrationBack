using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Utils
{
    public class HttpRequest
    {
        private readonly HttpClient _client;

        public HttpRequest()
        {
            _client = new HttpClient();
        }

        public async Task<T> SendAsync<T>(
            string url,
            HttpMethod method,
            object data = null,
            IDictionary<string, string> headers = null,
            string contentType = "application/json")
        {
            AddHeaders(headers);

            HttpRequestMessage request = new HttpRequestMessage(method, url);

            if (data != null)
            {
                if (contentType == "application/json")
                {
                    var json = JsonSerializer.Serialize(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                else if (contentType == "application/x-www-form-urlencoded" && data is IDictionary<string, string> formData)
                {
                    request.Content = new FormUrlEncodedContent(formData);
                }
                else
                {
                    throw new InvalidOperationException("Unsupported content type or data format");
                }
            }

            var response = await _client.SendAsync(request);
            return await HandleResponse<T>(response);
        }

        public async Task<byte[]> SendForBytesAsync(
            string url,
            HttpMethod method,
            object data = null,
            IDictionary<string, string> headers = null,
            string contentType = "application/json")
        {
            AddHeaders(headers);

            HttpRequestMessage request = new HttpRequestMessage(method, url);

            if (data != null)
            {
                if (contentType == "application/json")
                {
                    var json = JsonSerializer.Serialize(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                else if (contentType == "application/x-www-form-urlencoded" && data is IDictionary<string, string> formData)
                {
                    request.Content = new FormUrlEncodedContent(formData);
                }
                else
                {
                    throw new InvalidOperationException("Unsupported content type or data format");
                }
            }

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        private void AddHeaders(IDictionary<string, string> headers)
        {
            _client.DefaultRequestHeaders.Clear();
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
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
