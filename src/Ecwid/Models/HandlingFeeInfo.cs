// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using Newtonsoft.Json;

namespace Ecwid.Models
{
    /// <summary>
    /// HandlingFee charges.
    /// </summary>
    public class HandlingFeeInfo
    {
        /// <summary>
        /// Gets or sets the handling fee name set by store admin. E.g. Wrapping.
        /// </summary>
        /// <value>
        /// The name. E.g. Wrapping.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}