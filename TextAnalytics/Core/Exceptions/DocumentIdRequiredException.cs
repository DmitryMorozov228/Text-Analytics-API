﻿using System;

namespace TextAnalytics.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when a document id is not provided.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentIdRequiredException : Exception
    {
        #region Properties

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message => "A document's Id property is required.";

        #endregion Properties
    }
}
