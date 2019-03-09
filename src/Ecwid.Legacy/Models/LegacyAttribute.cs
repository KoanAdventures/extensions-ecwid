// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using Ecwid.Models;
using Newtonsoft.Json;

namespace Ecwid.Legacy.Models
{
    /// <inheritdoc />
    public class LegacyAttribute : BaseEntity
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// For built-in attributes, contains their internal name like 'Brand' or 'UPC'.
        /// </summary>
        /// <value>
        /// The name of the internal.
        /// </value>
        [JsonProperty("internalName")]
        public string InternalName { get; set; }
    }
}