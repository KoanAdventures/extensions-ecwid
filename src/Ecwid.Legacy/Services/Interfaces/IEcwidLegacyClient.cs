// Licensed under the GPL License, Version 3.0. See LICENSE in the git repository root for license information.

// ReSharper disable CheckNamespace

namespace Ecwid.Legacy
{
    /// <summary>
    /// Public client for Legacy EcwidAPI.
    /// </summary>
    public interface IEcwidLegacyClient : IEcwidOrdersLegacyClient, IEcwidProductsLegacyClient
    {
        /// <summary>
        /// Gets and sets the credentials. Default value is <see langword="null" />.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        EcwidLegacyCredentials Credentials { get; set; }

        /// <summary>
        /// Gets and sets the settings. Created by default.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        EcwidLegacySettings Settings { get; set; }

        /// <summary>
        /// Configures with specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <exception cref="EcwidHttpException">Something happened to the HTTP call.</exception>
        /// <exception cref="EcwidConfigException">Credentials are invalid.</exception>
        IEcwidLegacyClient Configure(EcwidLegacySettings settings);

        /// <summary>
        /// Configures the shop credentials.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <param name="orderToken">The shop order authorization token.</param>
        /// <param name="productToken">The shop product authorization token.</param>
        /// <exception cref="EcwidConfigException">The shop identifier is invalid.</exception>
        /// <exception cref="EcwidConfigException">The authorization tokens are null.</exception>
        /// <exception cref="EcwidConfigException">The order authorization token is invalid.</exception>
        /// <exception cref="EcwidConfigException">The product authorization token is invalid.</exception>
        IEcwidLegacyClient Configure(int shopId, string orderToken = null, string productToken = null);

        /// <summary>
        /// Configures with specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="EcwidHttpException">Something happened to the HTTP call.</exception>
        /// <exception cref="EcwidConfigException">Credentials are invalid.</exception>
        IEcwidLegacyClient Configure(EcwidLegacyCredentials credentials);
    }
}