﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core.Pipeline;

namespace Azure.Core.Http
{
    /// <summary>
    /// Defines a range of bytes within an HTTP resource, starting at an offset and
    /// ending at offset+count-1 inclusively.
    /// </summary>
    public readonly struct HttpRange : IEquatable<HttpRange>
    {
        // We only support using the "bytes" unit.
        private const string Unit = "bytes";

        /// <summary>
        /// Gets the starting offset of the <see cref="HttpRange"/>.
        /// </summary>
        public long Offset { get; }

        /// <summary>
        /// Gets the size of the <see cref="HttpRange"/>.  null means the range
        /// extends all the way to the end.
        /// </summary>
        public long? Count { get; }

        /// <summary>
        /// Creates an instance of HttpRange
        /// </summary>
        /// <param name="offset">null means offset is 0</param>
        /// <param name="count">null means to the end</param>
        public HttpRange(long? offset = default, long? count = default)
        {
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count.HasValue && count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            this.Offset = offset ?? 0;
            this.Count = count;
        }

        /// <summary>
        /// Converts the specified range to a string.
        /// </summary>
        /// <returns>String representation of the range.</returns>
        /// <remarks>For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-the-range-header-for-file-service-operations. </remarks>
        public override string ToString()
        {
            // No additional validation by design. API can validate parameter by case, and use this method.
            var endRange = "";
            if (this.Count.HasValue && this.Count != 0)
            {
                endRange = (this.Offset + this.Count.Value - 1).ToString(CultureInfo.InvariantCulture);
            }

            return FormattableString.Invariant($"{Unit}={this.Offset}-{endRange}");
        }

        /// <summary>
        /// Returns Range header for this range.
        /// </summary>
        /// <returns></returns>
        public HttpHeader ToRangeHeader() => new HttpHeader(HttpHeader.Names.Range, ToString());

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(HttpRange left, HttpRange right) => left.Equals(right);

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(HttpRange left, HttpRange right) => !(left == right);

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(HttpRange other) => this.Offset == other.Offset && this.Count == other.Count;

        /// <summary>
        /// Check if two <see cref="HttpRange"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HttpRange other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="HttpRange"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="HttpRange"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => HashCodeBuilder.Combine(Offset, Count);
    }
}
