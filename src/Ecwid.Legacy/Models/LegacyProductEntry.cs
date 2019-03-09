﻿// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using Ecwid.Models;
using Newtonsoft.Json;

namespace Ecwid.Legacy.Models
{
    /// <inheritdoc />
    public class LegacyProductEntry : BaseEntity
    {
        /// <summary>
        /// Gets or sets the SKU, that is, a unique code.
        /// </summary>
        /// <value>
        /// The sku.
        /// </value>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// If present, an URL of a small product thumbnail (usually 80x80).
        /// </summary>
        /// <value>
        /// The small thumbnail URL.
        /// </value>
        [JsonProperty("smallThumbnailUrl")]
        public string SmallThumbnailUrl { get; set; }

        /// <summary>
        /// If present, an URL of a product thumbnail (usually 160x160).
        /// </summary>
        /// <value>
        /// The thumbnail URL.
        /// </value>
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets the original image URL.
        /// </summary>
        /// <value>
        /// The original image URL.
        /// </value>
        [JsonProperty("originalImageUrl")]
        public string OriginalImageUrl { get; set; }

        /// <summary>
        /// If present, an URL of a product image, usually no more then 500x500.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// If present, product "compareTo" price.
        /// </summary>
        /// <value>
        /// The compare to price.
        /// </value>
        [JsonProperty("compareToPrice")]
        public double CompareToPrice { get; set; }

        /// <summary>
        /// If present, specifies the product weight, in the store units. Absent for intangible products.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the default combination.
        /// </summary>
        /// <value>
        /// The default combination.
        /// </value>
        [JsonProperty("defaultCombination")]
        public LegacyProductCombination DefaultCombination { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [JsonProperty("created")]
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets the Id of a product class this product belongs to (like 'Books').
        /// Zero '0' value means 'General' class, which is the default for products.
        /// LegacyProduct classes default additional attributes you can edit on the 'Attributes' tab in the product editor.
        /// See <see cref="LegacyProduct" /> class API below on how to manipulate product classes.
        /// </summary>
        /// <value>
        /// The product class identifier.
        /// </value>
        [JsonProperty("productClassId")]
        public int ProductClassId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LegacyProductEntry" /> is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [description truncated].
        /// </summary>
        /// <value>
        /// <c>true</c> if [description truncated]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("descriptionTruncated")]
        public bool DescriptionTruncated { get; set; }

        /// <summary>
        /// Gets or sets the favorites.
        /// </summary>
        /// <value>
        /// The favorites.
        /// </value>
        [JsonProperty("favorites")]
        public LegacyFavorites LegacyFavorites { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }
}