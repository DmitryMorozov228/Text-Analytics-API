using System.Threading.Tasks;
using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.Sentiment
{
    /// <summary>
    /// Client for interacting with the Text Analytics sentiment analysis API.
    /// </summary>
    /// <seealso cref="TextClient" />
    public class SentimentClient : TextClient
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentClient"/> class.
        /// </summary>
        /// <param name="apiKey">The Text Analytics API key.</param>
        public SentimentClient(string apiKey) : base(apiKey)
        {
            Url = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the sentiment for a collection of documents.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <see cref="SentimentResponse"/>
        /// <returns>Returns a SentimentResponse object from the Sentiment Analysis API.</returns>
        public SentimentResponse GetSentiment(SentimentRequest request)
        {
            return GetSentimentAsync(request).Result;
        }

        /// <summary>
        /// Gets the sentiment for a collection asynchronously.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <see cref="SentimentResponse"/>
        /// <returns>Returns a SentimentResponse object from the Sentiment Analysis API.</returns>
        public async Task<SentimentResponse> GetSentimentAsync(SentimentRequest request)
        {
            request.Validate();

            var url = Url;

            var json = JsonConvert.SerializeObject(request);
            var responseJson = await SendPostAsync(url, json);
            var response = JsonConvert.DeserializeObject<SentimentResponse>(responseJson);

            return response;
        }

        #endregion Methods
    }
}
