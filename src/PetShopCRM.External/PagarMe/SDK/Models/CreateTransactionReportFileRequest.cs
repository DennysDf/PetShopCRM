// <copyright file="CreateTransactionReportFileRequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace PagarmeApiSDK.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using JsonSubTypes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using PagarmeApiSDK.Standard;
    using PagarmeApiSDK.Standard.Utilities;

    /// <summary>
    /// CreateTransactionReportFileRequest.
    /// </summary>
    public class CreateTransactionReportFileRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTransactionReportFileRequest"/> class.
        /// </summary>
        public CreateTransactionReportFileRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTransactionReportFileRequest"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="startAt">start_at.</param>
        /// <param name="endAt">end_at.</param>
        public CreateTransactionReportFileRequest(
            string name,
            DateTime? startAt = null,
            string endAt = null)
        {
            this.Name = name;
            this.StartAt = startAt;
            this.EndAt = endAt;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets StartAt.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// Gets or sets EndAt.
        /// </summary>
        [JsonProperty("end_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndAt { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTransactionReportFileRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is CreateTransactionReportFileRequest other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.StartAt == null && other.StartAt == null) || (this.StartAt?.Equals(other.StartAt) == true)) &&
                ((this.EndAt == null && other.EndAt == null) || (this.EndAt?.Equals(other.EndAt) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.StartAt = {(this.StartAt == null ? "null" : this.StartAt.ToString())}");
            toStringOutput.Add($"this.EndAt = {(this.EndAt == null ? "null" : this.EndAt)}");
        }
    }
}