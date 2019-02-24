﻿// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ecwid.Models.Legacy
{
    /// <inheritdoc />
    public class LegacyCategory : LegacyCategoryEntry
    {
        /// <summary>
        /// Gets or sets the a list of the child subcategories, without nested products and subcategories.
        /// </summary>
        /// <value>
        /// The subcategories.
        /// </value>
        [JsonProperty("subcategories")]
        public IList<LegacyCategoryEntry> Subcategories { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        [JsonProperty("products")]
        public IList<LegacyProductEntry> Products { get; set; }
    }
}