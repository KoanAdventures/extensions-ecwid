﻿// Licensed under the MIT License. See LICENSE in the git repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ecwid.Models;
using Flurl;
using Flurl.Util;

// ReSharper disable PossibleMultipleEnumeration

namespace Ecwid
{
    public partial class EcwidClient
    {
        #region Implementation of IEcwidOrdersClient

        /// <inheritdoc />
        public OrdersQueryBuilder<OrderEntry, UpdateStatus> Orders
            => new OrdersQueryBuilder<OrderEntry, UpdateStatus>(this);

        /// <inheritdoc />
        public Task<bool> CheckOrdersTokenAsync()
            => CheckOrdersTokenAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<bool> CheckOrdersTokenAsync(CancellationToken cancellationToken)
            => CheckTokenAsync<SearchResult>(GetUrl("orders"), cancellationToken);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetNewOrdersAsync()
            => GetNewOrdersAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetNewOrdersAsync(CancellationToken cancellationToken)
            => GetOrdersAsync(new {fulfillmentStatus = "AWAITING_PROCESSING"}, cancellationToken);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetNonPaidOrdersAsync()
            => GetNonPaidOrdersAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetNonPaidOrdersAsync(CancellationToken cancellationToken)
            => GetOrdersAsync(new {paymentStatus = "AWAITING_PAYMENT"}, cancellationToken);

        /// <inheritdoc />
        public Task<int> GetOrdersCountAsync()
            => GetOrdersCountAsync(CancellationToken.None);

        /// <inheritdoc />
        public async Task<int> GetOrdersCountAsync(CancellationToken cancellationToken)
            => (await GetApiAsync<SearchResult>(GetUrl("orders"), new {limit = 1}, cancellationToken)).Total;

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetPaidNotShippedOrdersAsync()
            => GetPaidNotShippedOrdersAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetPaidNotShippedOrdersAsync(CancellationToken cancellationToken)
            =>
                GetOrdersAsync(new {paymentStatus = "PAID", fulfillmentStatus = "AWAITING_PROCESSING,PROCESSING"},
                    cancellationToken);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetShippedOrdersAsync()
            => GetShippedOrdersAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetShippedOrdersAsync(CancellationToken cancellationToken)
            => GetOrdersAsync(new {fulfillmentStatus = "SHIPPED"}, cancellationToken);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetOrdersAsync(object query)
            => GetOrdersAsync(query, CancellationToken.None);

        /// <inheritdoc />
        public async Task<IEnumerable<OrderEntry>> GetOrdersAsync(object query, CancellationToken cancellationToken)
        {
            var response = await GetApiAsync<SearchResult>(GetUrl("orders"), query, cancellationToken);

            var result = response.Orders ?? Enumerable.Empty<OrderEntry>();

            // return if response is null or response is full
            if (result.FirstOrDefault() == null)
            {
                return result;
            }

            if (response.Total == response.Count)
            {
                return result;
            }

            // if query is not null check it contains limit or offset.
            if (query?.ToKeyValuePairs().Count(pair => pair.Key == "limit" || pair.Key == "offset") > 0)
            {
                return result;
            }

            while (response.Count == response.Limit)
            {
                response =
                    await
                        GetApiAsync<SearchResult>(
                            GetUrl("orders").SetQueryParams(
                                new {offset = response.Offset + response.Limit}), query, cancellationToken);

                if (response.Orders != null)
                {
                    result = result.Concat(response.Orders);
                }
            }

            return result;
        }

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetIncompleteOrdersAsync()
            => GetIncompleteOrdersAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<IEnumerable<OrderEntry>> GetIncompleteOrdersAsync(CancellationToken cancellationToken)
            => GetOrdersAsync(new {paymentStatus = "INCOMPLETE"}, cancellationToken);

        /// <inheritdoc />
        public Task<OrderEntry> GetOrderAsync(string orderId)
            => GetOrderAsync(orderId, CancellationToken.None);

        /// <inheritdoc />
        public async Task<OrderEntry> GetOrderAsync(string orderId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("Order Id is empty.", nameof(orderId));

            return await GetApiAsync<OrderEntry>(GetUrl($"orders/{orderId}"), cancellationToken);
        }

        /// <inheritdoc />
        public Task<UpdateStatus> UpdateOrderAsync(OrderEntry order, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(order.Id)) throw new ArgumentException("Order Id is empty.", nameof(order));
            return PutApiAsync<UpdateStatus>(GetUrl($"orders/{order.Id}"), order, cancellationToken);
        }

        /// <inheritdoc />
        public Task<UpdateStatus> UpdateOrderAsync(OrderEntry order)
            => UpdateOrderAsync(order, CancellationToken.None);

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteOrderAsync(OrderEntry order, CancellationToken cancellationToken)
            => DeleteOrderAsync(order.Id, cancellationToken);

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteOrderAsync(OrderEntry order)
            => DeleteOrderAsync(order.Id);

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteOrderAsync(string orderId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(orderId)) throw new ArgumentException("Order Id is empty.", nameof(orderId));
            return DeleteApiAsync<DeleteStatus>(GetUrl($"orders/{orderId}"), cancellationToken);
        }

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteOrderAsync(string orderId)
            => DeleteOrderAsync(orderId, CancellationToken.None);

        #endregion
    }
}