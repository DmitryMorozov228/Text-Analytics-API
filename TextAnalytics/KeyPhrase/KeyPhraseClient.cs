﻿using System.Threading.Tasks;
using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.KeyPhrase
{
    /// <summary>
    /// Client for interacting with the Text Analytics key phrase detection API.
    /// </summary>
    /// <seealso cref="TextClient" />
    public class KeyPhraseClient : TextClient
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPhraseClient"/> class.
        /// </summary>
        /// <param name="apiKey">The Text Analytics API key.</param>
        public KeyPhraseClient(string apiKey) : base(apiKey)
        {
            Url = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the key phrases.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public KeyPhraseResponse GetKeyPhrases(KeyPhraseRequest request)
        {
            return GetKeyPhrasesAsync(request).Result;
        }

        /// <summary>
        /// Gets the key phrases asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<KeyPhraseResponse> GetKeyPhrasesAsync(KeyPhraseRequest request)
        {
            request.Validate();

            var url = Url;

            var json = JsonConvert.SerializeObject(request);
            var responseJson = await SendPostAsync(url, json);
            var response = JsonConvert.DeserializeObject<KeyPhraseResponse>(responseJson);

            return response;
        }

        #endregion Methods
    }
}
