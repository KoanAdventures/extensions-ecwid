// Licensed under the GPL License, Version 3.0. See LICENSE in the git repository root for license information.
// Licensed under the GPL License, Version 3.0. See LICENSE in the git repository root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ecwid.Models;

namespace Ecwid
{
    /// <summary>
    /// Shared public orders client API.
    /// </summary>
    /// <typeparam name="TOrder">The type of the order.</typeparam>
    /// <typeparam name="TUpdateResponse">The type of the update response.</typeparam>
    public interface IEcwidOrdersClient<TOrder, TUpdateResponse>
        where TOrder : BaseOrder
        where TUpdateResponse : class
    {
        /// <summary>
        /// Gets the orders query builder.
        /// </summary>
        /// <example>
        /// This sample shows how to gets last 10 orders by the <see cref="OrdersQueryBuilder{TOrder,TUpdateResponse}" />.
        /// <code>
        /// var orders = client.Configure(credentials).Orders.Limit(10).GetAsync();
        /// </code>
        /// </example>
        /// <value>
        /// The orders.
        /// </value>
        OrdersQueryBuilder<TOrder, TUpdateResponse> Orders { get; }

        /// <summary>
        /// Checks the shop authentication asynchronous.
        /// </summary>
        Task<bool> CheckOrdersTokenAsync();

        /// <summary>
        /// Checks the shop authentication asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<bool> CheckOrdersTokenAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the new orders asynchronous. This orders is new or is not processed.
        /// </summary>
        Task<List<TOrder>> GetNewOrdersAsync();

        /// <summary>
        /// Gets the new orders asynchronous. This orders is new or is not processed.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<List<TOrder>> GetNewOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the non paid orders asynchronous.
        /// </summary>
        Task<List<TOrder>> GetNonPaidOrdersAsync();

        /// <summary>
        /// Gets the non paid orders asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<List<TOrder>> GetNonPaidOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the orders asynchronous. If <paramref name="query" /> contains limit or offset parameters gets only one page.
        /// </summary>
        /// <param name="query">
        /// The query. It's a list of key-value pairs. e.g.
        /// <code>new {fulfillmentStatus = "SHIPPED", limit = 100}</code> or Dictionary{string, object}
        /// </param>
        Task<List<TOrder>> GetOrdersAsync(object query);

        /// <summary>
        /// Gets the orders asynchronous. If <paramref name="query" /> contains limit or offset parameters gets only one page.
        /// </summary>
        /// <param name="query">
        /// The query. It's a list of key-value pairs. e.g.
        /// <code>new {fulfillmentStatus = "SHIPPED", limit = 100}</code> or Dictionary{string, object}
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<List<TOrder>> GetOrdersAsync(object query, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the orders count asynchronous.
        /// </summary>
        Task<int> GetOrdersCountAsync();

        /// <summary>
        /// Gets the orders count asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<int> GetOrdersCountAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the paid and not shipped orders asynchronous.
        /// </summary>
        Task<List<TOrder>> GetPaidNotShippedOrdersAsync();

        /// <summary>
        /// Gets the paid and not shipped orders asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<List<TOrder>> GetPaidNotShippedOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the shipped and not delivered orders asynchronous.
        /// </summary>
        Task<List<TOrder>> GetShippedOrdersAsync();

        /// <summary>
        /// Gets the shipped and not delivered orders asynchronous.
        /// </summary>
        Task<List<TOrder>> GetShippedOrdersAsync(CancellationToken cancellationToken);
    }

    /// <inheritdoc />
    public interface IEcwidOrdersClient : IEcwidOrdersClient<OrderEntry, UpdateStatus>
    {
        /// <summary>
        /// Gets the incomplete orders asynchronous. This orders is new or is not processed.
        /// </summary>
        /// <exception cref="EcwidConfigException">Credentials are invalid.</exception>
        /// <exception cref="EcwidHttpException">Something happened to the HTTP call.</exception>
        Task<List<OrderEntry>> GetIncompleteOrdersAsync();

        /// <summary>
        /// Gets the incomplete orders asynchronous. This orders is new or is not processed.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="EcwidConfigException">Credentials are invalid.</exception>
        /// <exception cref="EcwidHttpException">Something happened to the HTTP call.</exception>
        Task<List<OrderEntry>> GetIncompleteOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the one order asynchronous.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="orderNumber" /> is out of range.</exception>
        /// <exception cref="EcwidConfigException">Credentials are invalid.</exception>
        /// <exception cref="EcwidHttpException">Something happened to the HTTP call.</exception>
        Task<OrderEntry> GetOrderAsync(int orderNumber);

        /// <summary>
        /// Gets the one orders asynchronous.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="orderNumber" /> is out of range.</exception>
        /// <exception cref="EcwidConfigException">Credentials are invalid.</exception>
        /// <exception cref="EcwidHttpException">Something happened to the HTTP call.</exception>
        Task<OrderEntry> GetOrderAsync(int orderNumber, CancellationToken cancellationToken);
        /// <summary>
        /// Update one order asynchronously.
        /// </summary>
        /// <param name="order">The order to update.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="EcwidConfigException">Order number is 0.</exception>
        Task<UpdateStatus> UpdateOrderAsync(OrderEntry order, CancellationToken cancellationToken);

        /// <summary>
        /// Update one order asynchronously.
        /// </summary>
        /// <param name="order">The order to update.</param>
        /// <exception cref="EcwidConfigException">Order number is 0.</exception>
        Task<UpdateStatus> UpdateOrderAsync(OrderEntry order);

        /// <summary>
        /// Delete one order asynchronously.
        /// </summary>
        /// <param name="order">The order to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="EcwidConfigException">Order number is 0.</exception>
        Task<DeleteStatus> DeleteOrderAsync(OrderEntry order, CancellationToken cancellationToken);

        /// <summary>
        /// Delete one order asynchronously.
        /// </summary>
        /// <param name="order">The order to delete.</param>
        /// <exception cref="EcwidConfigException">Order number is 0.</exception>
        Task<DeleteStatus> DeleteOrderAsync(OrderEntry order);

        /// <summary>
        /// Delete one order asynchronously.
        /// </summary>
        /// <param name="orderNumber">The order number to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="EcwidConfigException">Order number is 0.</exception>
        Task<DeleteStatus> DeleteOrderAsync(int orderNumber, CancellationToken cancellationToken);

        /// <summary>
        /// Delete one order asynchronously.
        /// </summary>
        /// <param name="orderNumber">The order number to delete.</param>
        /// <exception cref="EcwidConfigException">Order number is 0.</exception>
        Task<DeleteStatus> DeleteOrderAsync(int orderNumber);
    }
}