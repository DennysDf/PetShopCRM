// <copyright file="CreateBankTransferPaymentRequest.cs" company="APIMatic">
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
    /// CreateBankTransferPaymentRequest.
    /// </summary>
    public class CreateBankTransferPaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBankTransferPaymentRequest"/> class.
        /// </summary>
        public CreateBankTransferPaymentRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBankTransferPaymentRequest"/> class.
        /// </summary>
        /// <param name="bank">bank.</param>
        /// <param name="retries">retries.</param>
        public CreateBankTransferPaymentRequest(
            string bank,
            int retries)
        {
            this.Bank = bank;
            this.Retries = retries;
        }

        /// <summary>
        /// Bank
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; }

        /// <summary>
        /// Number of retries
        /// </summary>
        [JsonProperty("retries")]
        public int Retries { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateBankTransferPaymentRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateBankTransferPaymentRequest other &&                ((this.Bank == null && other.Bank == null) || (this.Bank?.Equals(other.Bank) == true)) &&
                this.Retries.Equals(other.Retries);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Bank = {(this.Bank == null ? "null" : this.Bank)}");
            toStringOutput.Add($"this.Retries = {this.Retries}");
        }
    }
}