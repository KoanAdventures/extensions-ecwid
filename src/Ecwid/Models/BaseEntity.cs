// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using Newtonsoft.Json;

namespace Ecwid.Models
{
    /// <summary>
    /// Base entity contains identifier
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        /// <value>
        /// The identifier
        /// </value>
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
