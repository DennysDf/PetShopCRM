// <copyright file="UpdateSubscriptionStartAtRequest.cs" company="APIMatic">
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
    /// UpdateSubscriptionStartAtRequest.
    /// </summary>
    public class UpdateSubscriptionStartAtRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionStartAtRequest"/> class.
        /// </summary>
        public UpdateSubscriptionStartAtRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionStartAtRequest"/> class.
        /// </summary>
        /// <param name="startAt">start_at.</param>
        public UpdateSubscriptionStartAtRequest(
            DateTime startAt)
        {
            this.StartAt = startAt;
        }

        /// <summary>
        /// The date when the subscription periods will start
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("start_at")]
        public DateTime StartAt { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateSubscriptionStartAtRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateSubscriptionStartAtRequest other &&                this.StartAt.Equals(other.StartAt);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartAt = {this.StartAt}");
        }
    }
}