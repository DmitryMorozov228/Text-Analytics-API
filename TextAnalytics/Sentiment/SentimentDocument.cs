using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.Sentiment
{
    /// <summary>
    /// Document to submit to the Text Analytics API for sentiment analysis.
    /// </summary>
    /// <seealso cref="Document" />
    /// /// <seealso cref="IDocument" />
    public class SentimentDocument : Document
    {
        #region Properties

        /// <summary>
        /// Gets or sets the language the text is in.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [JsonProperty("language")]
        public string Language { get; set; }

        #endregion Properties
    }
}
