// <copyright file="HttpResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace PagarmeApiSDK.Standard.Http.Response
{
    using System.IO;
    using System.Collections.Generic;
    using APIMatic.Core.Types.Sdk;

    /// <summary>
    /// HttpResponse stores necessary information about the http response.
    /// </summary>
    public class HttpResponse : CoreResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse"/> class.
        /// </summary>
        /// <param name="statusCode">statusCode.</param>
        /// <param name="headers">headers.</param>
        /// <param name="rawBody">rawBody.</param>
        /// <param name="body">body.</param>
        public HttpResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body = null)
            : base(statusCode, headers, rawBody, body) { }
    }
}
