// <copyright file="UpdateSubscriptionDueDaysRequest.cs" company="APIMatic">
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
    /// UpdateSubscriptionDueDaysRequest.
    /// </summary>
    public class UpdateSubscriptionDueDaysRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionDueDaysRequest"/> class.
        /// </summary>
        public UpdateSubscriptionDueDaysRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionDueDaysRequest"/> class.
        /// </summary>
        /// <param name="boletoDueDays">boleto_due_days.</param>
        public UpdateSubscriptionDueDaysRequest(
            int boletoDueDays)
        {
            this.BoletoDueDays = boletoDueDays;
        }

        /// <summary>
        /// Gets or sets BoletoDueDays.
        /// </summary>
        [JsonProperty("boleto_due_days")]
        public int BoletoDueDays { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateSubscriptionDueDaysRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateSubscriptionDueDaysRequest other &&                this.BoletoDueDays.Equals(other.BoletoDueDays);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BoletoDueDays = {this.BoletoDueDays}");
        }
    }
}