﻿// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using Newtonsoft.Json;

namespace Ecwid.Models
{
    /// <summary>
    /// Represent credit card status. 
    /// </summary>
    public class CreditCardStatus
    {
        /// <summary>
        /// Gets or sets the address verification status returned by some payment systems.
        /// </summary>
        /// <value>
        /// The avs message.
        /// </value>
        [JsonProperty("avsMessage")]
        public string AvsMessage { get; set; }

        /// <summary>
        /// Gets or sets the credit card verification status returned by some payment systems.
        /// </summary>
        /// <value>
        /// The CVV message.
        /// </value>
        [JsonProperty("cvvMessage")]
        public string CvvMessage { get; set; }
    }
}