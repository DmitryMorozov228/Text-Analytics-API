﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace TextAnalytics.KeyPhrase
{
    /// <summary>
    /// Key phrases detected by the Text Analytics API.
    /// </summary>
    public class KeyPhraseDocumentResult
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the document.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the key phrases.
        /// </summary>
        /// <value>
        /// The key phrases.
        /// </value>
        [JsonProperty("keyPhrases")]
        public List<string> KeyPhrases { get; set; }

        #endregion Properties
    }
}
