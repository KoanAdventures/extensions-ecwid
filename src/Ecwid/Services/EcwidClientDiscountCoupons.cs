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
        private const string DiscountCouponsUrl = "discount_coupons";

        #region Implementation of IEcwidDiscountCouponsClient

        /// <inheritdoc />
        public Task<bool> CheckDiscountCouponsTokenAsync()
            => CheckDiscountCouponsTokenAsync(CancellationToken.None);

        /// <inheritdoc />
        public Task<bool> CheckDiscountCouponsTokenAsync(CancellationToken cancellationToken)
            => CheckTokenAsync<DiscountCouponSearchResults>(GetUrl(DiscountCouponsUrl), Credentials, cancellationToken);

        /// <inheritdoc />
        public Task<DiscountCouponInfo> GetDiscountCouponAsync(string couponIdentifier) =>
            GetDiscountCouponAsync(couponIdentifier, CancellationToken.None);

        /// <inheritdoc />
        public async Task<DiscountCouponInfo> GetDiscountCouponAsync(string couponIdentifier,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(couponIdentifier))
                throw new ArgumentNullException(nameof(couponIdentifier));

            var discountCoupons =
                await GetDiscountCouponsAsync(new {couponIdentifier}, cancellationToken);

            return discountCoupons.FirstOrDefault();
        }

        /// <inheritdoc />
        public Task<IEnumerable<DiscountCouponInfo>> GetDiscountCouponsAsync(object query) =>
            GetDiscountCouponsAsync(query, CancellationToken.None);

        /// <inheritdoc />
        public async Task<IEnumerable<DiscountCouponInfo>> GetDiscountCouponsAsync(object query,
            CancellationToken cancellationToken)
        {
            var response =
                await GetApiAsync<DiscountCouponSearchResults>(GetUrl(DiscountCouponsUrl), Credentials, query, cancellationToken);

            var result = response.DiscountCoupons ?? Enumerable.Empty<DiscountCouponInfo>();

            if (result.FirstOrDefault() == null)
            {
                return result;
            }

            if (response.Total == response.Count)
            {
                return result;
            }

            if (query?.ToKeyValuePairs().Count(pair => pair.Key == "limit" || pair.Key == "offset") > 0)
            {
                return result;
            }

            while (response.Count == response.Limit)
            {
                response =
                    await
                        GetApiAsync<DiscountCouponSearchResults>(
                            GetUrl(DiscountCouponsUrl).SetQueryParams(new {offset = response.Offset + response.Limit}),
                            Credentials,
                            query,
                            cancellationToken);

                // ReSharper disable once ExceptionNotDocumentedOptional
                if (response.DiscountCoupons != null)
                {
                    result = result.Concat(response.DiscountCoupons);
                }
            }

            return result;
        }

        /// <inheritdoc />
        public Task<DiscountCouponCreateStatus> CreateDiscountCouponAsync(DiscountCouponInfo coupon)
            => CreateDiscountCouponAsync(coupon, CancellationToken.None);

        /// <inheritdoc />
        public Task<DiscountCouponCreateStatus> CreateDiscountCouponAsync(DiscountCouponInfo coupon,
            CancellationToken cancellationToken)
        {
            return PostJsonApiAsync<DiscountCouponCreateStatus>(GetUrl(DiscountCouponsUrl), Credentials, coupon,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<UpdateStatus> UpdateDiscountCouponAsync(DiscountCouponInfo coupon)
            => UpdateDiscountCouponAsync(coupon, CancellationToken.None);

        /// <inheritdoc />
        public Task<UpdateStatus> UpdateDiscountCouponAsync(DiscountCouponInfo coupon,
            CancellationToken cancellationToken)
        {
            if (coupon == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrWhiteSpace(coupon.Code))
            {
                throw new ArgumentException("Coupon code must have a value", nameof(coupon.Code));
            }

            return PutApiAsync<UpdateStatus>(GetUrl($"{DiscountCouponsUrl}/{coupon.Code}"), Credentials, coupon,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteDiscountCouponAsync(DiscountCouponInfo coupon)
            => DeleteDiscountCouponAsync(coupon.Code);

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteDiscountCouponAsync(string couponIdentifier,
            CancellationToken cancellationToken) =>
            DeleteApiAsync<DeleteStatus>(GetUrl($"{DiscountCouponsUrl}/{couponIdentifier}"), Credentials,
                cancellationToken);

        /// <inheritdoc />
        public Task<DeleteStatus> DeleteDiscountCouponAsync(string couponIdentifier)
            => DeleteDiscountCouponAsync(couponIdentifier, CancellationToken.None);

        #endregion
    }
}