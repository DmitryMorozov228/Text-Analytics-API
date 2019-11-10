using System;

namespace TextAnalytics.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when a collection does not have the minimum number of documents.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentCollectionMinDocumentException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentCollectionMinDocumentException"/> class.
        /// </summary>
        /// <param name="documentCount">The dcount of documents in the collection.</param>
        /// <param name="minimumDocumentCount">The minimum number of documents in a collection.</param>
        public DocumentCollectionMinDocumentException(int documentCount, int minimumDocumentCount)
        {
            this.DocumentCount = documentCount;
            this.MinimumDocumentCount = minimumDocumentCount;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the count of documents in the collection.
        /// </summary>
        /// <value>
        /// The document count.
        /// </value>
        public int DocumentCount { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of documents in a collection.
        /// </summary>
        /// <value>
        /// The minimum document count.
        /// </value>
        public int MinimumDocumentCount { get; set; }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message => $"Document collection has {DocumentCount} documents. The minimum number of documents for a collection is {MinimumDocumentCount}.";

        #endregion Properties
    }
}
