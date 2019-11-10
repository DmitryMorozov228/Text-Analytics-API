using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.Languages
{
    /// <summary>
    /// Request for interacting with the Text Analytics language identification API.
    /// </summary>
    /// <seealso cref="TextRequest" />
    public class LanguageRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageRequest"/> class.
        /// </summary>
        public LanguageRequest()
        {
            NumberOfLanguagesToDetect = 1;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the number of languages to detect.
        /// </summary>
        /// <value>
        /// The number of languages to detect.
        /// </value>
        [JsonIgnore]
        public int NumberOfLanguagesToDetect { get; set; }

        #endregion Properties

    }
}
