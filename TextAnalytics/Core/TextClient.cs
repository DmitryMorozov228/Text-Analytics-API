using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalytics.Core
{
    /// <summary>
    /// Client for interacting with the Text Analytics API's. This is an abstract class.
    /// </summary>
    public abstract class TextClient
    {
        #region Fields

        private const string ApplicationJsonContentType = "application/json";
        private const string OcpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextClient"/> class.
        /// </summary>
        /// <param name="apiKey">The Text Analytics API key.</param>
        protected TextClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the Text Analytics API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the Text Analytics service URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sends the post to the Text Analytics API.
        /// </summary>
        /// <param name="data">The data to post to the Text Analytics API in json format.</param>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        protected string SendPost(string data)
        {
            return SendPost(Url, data);
        }

        /// <summary>
        /// Sends the post to the Text Analytics API.
        /// </summary>
        /// <param name="url">The URL of the Text Analytics API.</param>
        /// <param name="data">The data to post to the Text Analytics API in json format.</param>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        protected string SendPost(string url, string data)
        {
            return SendPostAsync(url, data).Result;
        }

        /// <summary>
        /// Sends the post to the Text Analytics API asynchronously.
        /// </summary>
        /// <param name="data">The data to post to the Text Analytics API in json format.</param>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        protected async Task<string> SendPostAsync(string data)
        {
            return await SendPostAsync(Url, data);
        }

        /// <summary>
        /// Sends the post to the Text Analytics API asynchronously.
        /// </summary>
        /// <param name="url">The URL of the Text Analytics API.</param>
        /// <param name="data">The data to post to the Text Analytics API in json format.</param>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when either the URL or API key is provided.
        /// </exception>
        protected async Task<string> SendPostAsync(string url, string data)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(nameof(url));
            }

            if (String.IsNullOrWhiteSpace(ApiKey))
            {
                throw new ArgumentException(nameof(ApiKey));
            }

            if (String.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException(nameof(data));
            }

            string responseData;

            using (var client = new HttpClient { BaseAddress = new Uri(url) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJsonContentType));
                client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, ApiKey);

                var content = new StringContent(data, Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(url, content))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }

            return responseData;
        }

        /// <summary>
        /// Sends the get to the Text Analytics API.
        /// </summary>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        protected string SendGet()
        {
            return SendGet(Url);
        }

        /// <summary>
        /// Sends the get to the Text Analytics API.
        /// </summary>
        /// <param name="url">The URL of the Text Analytics API.</param>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        protected string SendGet(string url)
        {
            return SendGetAsync(url).Result;
        }

        /// <summary>
        /// Sends the get to the Text Analytics API asynchronously.
        /// </summary>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        protected async Task<string> SendGetAsync()
        {
            return await SendGetAsync(Url);
        }

        /// <summary>
        /// Sends the get to the Text Analytics API asynchronously.
        /// </summary>
        /// <param name="url">The URL of the Text Analytics API.</param>
        /// <returns>Returns a JSON string from the Text Analytics API.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when either the URL or API key is provided.
        /// </exception>
        protected async Task<string> SendGetAsync(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(nameof(url));
            }

            if (String.IsNullOrWhiteSpace(ApiKey))
            {
                throw new ArgumentException(nameof(ApiKey));
            }

            string responseData;

            using (var client = new HttpClient { BaseAddress = new Uri(url) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJsonContentType));
                client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, ApiKey);

                using (var response = await client.GetAsync(url))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }

            return responseData;
        }

        #endregion Methods
    }
}