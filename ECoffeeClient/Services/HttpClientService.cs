using System.Text.Json;

namespace ECoffeeClient.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<TResponse> DeleteAsync<TResponse>(RequestParameter requestParameter, string id)
        {
            string url = Url(requestParameter);
            url = (!String.IsNullOrEmpty(id) ? $"{url}/{id}" : url);
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(url);
            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> GetAsync<TResponse>(RequestParameter requestParameter, string id = null)
        {
            JsonSerializerOptions options = new();
            options.PropertyNameCaseInsensitive = true;
            string url = Url(requestParameter);
            url = (!String.IsNullOrEmpty(id) ? $"{url}/{id}" : url);
            return await _httpClient.GetFromJsonAsync<TResponse>(url, options);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body)
        {
            string url = Url(requestParameter);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync<TRequest>(url, body);
            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body)
        {
            string url = Url(requestParameter);
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync<TRequest>(url, body);
            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        private string Url(RequestParameter requestParameter)
        {
            string url = String.Empty;
            url = $"{(!String.IsNullOrEmpty(requestParameter.BaseUrl) ? requestParameter.BaseUrl : _configuration["BaseUrl"])}{requestParameter.Controller}/{(!String.IsNullOrEmpty(requestParameter.Action) ? requestParameter.Action : "")}{(!String.IsNullOrEmpty(requestParameter.QueryString) ? "?" + requestParameter.QueryString : "/")}";

            url = (!String.IsNullOrEmpty(requestParameter.FullEndPoint) ? requestParameter.FullEndPoint : url);

            return url;
        }


    }
}
