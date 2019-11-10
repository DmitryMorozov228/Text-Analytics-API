using System.Collections.Generic;
using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.KeyPhrase
{
    /// <summary>
    /// Response from the Text Analytics key phrase detection API.
    /// </summary>
    public class KeyPhraseResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPhraseResponse"/> class.
        /// </summary>
        public KeyPhraseResponse()
        {
            Documents = new List<KeyPhraseDocumentResult>();
            Errors = new List<DocumentError>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>
        /// The documents.
        /// </value>
        [JsonProperty("documents")]
        public List<KeyPhraseDocumentResult> Documents { get; set; }

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
