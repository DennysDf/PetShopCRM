// <copyright file="UpdateSubscriptionPaymentMethodRequest.cs" company="APIMatic">
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
    /// UpdateSubscriptionPaymentMethodRequest.
    /// </summary>
    public class UpdateSubscriptionPaymentMethodRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPaymentMethodRequest"/> class.
        /// </summary>
        public UpdateSubscriptionPaymentMethodRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPaymentMethodRequest"/> class.
        /// </summary>
        /// <param name="paymentMethod">payment_method.</param>
        /// <param name="cardId">card_id.</param>
        /// <param name="card">card.</param>
        /// <param name="cardToken">card_token.</param>
        /// <param name="boleto">boleto.</param>
        public UpdateSubscriptionPaymentMethodRequest(
            string paymentMethod,
            string cardId,
            Models.CreateCardRequest card,
            string cardToken = null,
            Models.CreateSubscriptionBoletoRequest boleto = null)
        {
            this.PaymentMethod = paymentMethod;
            this.CardId = cardId;
            this.Card = card;
            this.CardToken = cardToken;
            this.Boleto = boleto;
        }

        /// <summary>
        /// The new payment method
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Card id
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// Card data
        /// </summary>
        [JsonProperty("card")]
        public Models.CreateCardRequest Card { get; set; }

        /// <summary>
        /// The Card Token
        /// </summary>
        [JsonProperty("card_token", NullValueHandling = NullValueHandling.Ignore)]
        public string CardToken { get; set; }

        /// <summary>
        /// Information about fines and interest on the "boleto" used from payment
        /// </summary>
        [JsonProperty("boleto", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CreateSubscriptionBoletoRequest Boleto { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateSubscriptionPaymentMethodRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateSubscriptionPaymentMethodRequest other &&                ((this.PaymentMethod == null && other.PaymentMethod == null) || (this.PaymentMethod?.Equals(other.PaymentMethod) == true)) &&
                ((this.CardId == null && other.CardId == null) || (this.CardId?.Equals(other.CardId) == true)) &&
                ((this.Card == null && other.Card == null) || (this.Card?.Equals(other.Card) == true)) &&
                ((this.CardToken == null && other.CardToken == null) || (this.CardToken?.Equals(other.CardToken) == true)) &&
                ((this.Boleto == null && other.Boleto == null) || (this.Boleto?.Equals(other.Boleto) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentMethod = {(this.PaymentMethod == null ? "null" : this.PaymentMethod)}");
            toStringOutput.Add($"this.CardId = {(this.CardId == null ? "null" : this.CardId)}");
            toStringOutput.Add($"this.Card = {(this.Card == null ? "null" : this.Card.ToString())}");
            toStringOutput.Add($"this.CardToken = {(this.CardToken == null ? "null" : this.CardToken)}");
            toStringOutput.Add($"this.Boleto = {(this.Boleto == null ? "null" : this.Boleto.ToString())}");
        }
    }
}