using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.KeyPhrase
{
    /// <summary>
    /// Document to submit to the Text Analytics API for key phrase detection.
    /// </summary>
    /// <seealso cref="Document" />
    /// <seealso cref="IDocument" />
    public class KeyPhraseDocument : Document, IDocument
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
