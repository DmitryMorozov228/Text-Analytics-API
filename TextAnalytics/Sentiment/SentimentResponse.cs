using System.Collections.Generic;
using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.Sentiment
{
    /// <summary>
    /// Response from the Text Analytics sentiment analysis API.
    /// </summary>
    public class SentimentResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentResponse"/> class.
        /// </summary>
        public SentimentResponse()
        {
            Documents = new List<SentimentDocumentResult>();
            Errors = new List<DocumentError>();
        }

        #endregion  Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>
        /// The documents.
        /// </value>
        [JsonProperty("documents")]
        public List<SentimentDocumentResult> Documents { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [JsonProperty("errors")]
        public List<DocumentError> Errors { get; set; }

        #endregion Properties
    }
}
