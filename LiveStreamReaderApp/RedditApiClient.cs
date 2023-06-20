using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace LiveStreamReaderApp
{
    public interface IRedditApiClient
    {
        Task<string> GetLiveStreamingThread(string threadId);
    }

    public class RedditApiClient : IRedditApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.reddit.com";

        public RedditApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetLiveStreamingThread(string threadId)
        {
            try
            {
                string endpointUrl = $"{BaseUrl}/live/18hnzysb1elcs.json";
                HttpResponseMessage response = await _httpClient.GetAsync(endpointUrl);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving live streaming thread: {ex.Message}");
                return null;
            }
        }
    }
}




