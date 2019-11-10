using System.Collections.Generic;
using TextAnalytics.Core;
using TextAnalytics.Core.Exceptions;

namespace TextAnalytics.KeyPhrase
{
    /// <summary>
    /// Request for interacting with the Text Analytics key phrase detection API.
    /// </summary>
    /// <seealso cref="TextRequest" />
    public class KeyPhraseRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPhraseRequest"/> class.
        /// </summary>
        public KeyPhraseRequest()
        {
            Documents = new List<IDocument>();
            ValidLanguages = new List<string>() { "en", "es", "de", "ja", "fr" };
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

            if (ValidLanguages != null && ValidLanguages.Count > 0)
            {
                foreach (var document in Documents)
                {
                    var keyPhraseDocument = document as KeyPhraseDocument;

                    if (!ValidLanguages.Contains(keyPhraseDocument.Language))
                    {
                        throw new LanguageNotSupportedException(keyPhraseDocument.Language, ValidLanguages);
                    }
                }
            }
        }

        #endregion Methods
    }
}
