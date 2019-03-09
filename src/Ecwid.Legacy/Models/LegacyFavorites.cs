// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using Newtonsoft.Json;

namespace Ecwid.Legacy.Models
{
    /// <summary>
    /// Represent favorites for product.
    /// </summary>
    public class LegacyFavorites
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the displayed count.
        /// </summary>
        /// <value>
        /// The displayed count.
        /// </value>
        [JsonProperty("displayedCount")]
        public string DisplayedCount { get; set; }
    }
}