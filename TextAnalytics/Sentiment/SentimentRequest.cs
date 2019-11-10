using System.Collections.Generic;
using TextAnalytics.Core;
using TextAnalytics.Core.Exceptions;

namespace TextAnalytics.Sentiment
{
    /// <summary>
    /// Request for interacting with the Text Analytics sentiment analysis API.
    /// </summary>
    /// <seealso cref="TextRequest" />
    public class SentimentRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentRequest"/> class.
        /// </summary>
        public SentimentRequest()
        {
            Documents = new List<IDocument>();
            ValidLanguages = new List<string>() { "en", "es", "fr", "pt", "da", "de", "el", "fi", "it", "nl", "no", "pl", "ru", "sv", "tr" };
        }

        #endregion  Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the valid languages.
        /// </summary>
        /// <value>
        /// The valid languages.
        /// </value>
        public List<string> ValidLanguages { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <exception cref="LanguageNotSupportedException"></exception>
        public override void Validate()
        {
            base.Validate();

            if(ValidLanguages != null && ValidLanguages.Count >0)
            {
                foreach(var document in Documents)
                {
                    var sentimentDocument = document as SentimentDocument;

                    if (!string.IsNullOrEmpty(sentimentDocument.Language))
                    {
                        if (!ValidLanguages.Contains(sentimentDocument.Language))
                        {
                            throw new LanguageNotSupportedException(sentimentDocument.Language, ValidLanguages);
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}
