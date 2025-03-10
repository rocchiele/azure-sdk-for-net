﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies standard HTTP access conditions.
    /// </summary>
    public struct HttpAccessConditions : IEquatable<HttpAccessConditions>
    {
        /// <summary>
        /// Optionally limit requests to resources that have only been
        /// modified since this point in time.
        /// </summary>
        public DateTimeOffset? IfModifiedSince { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that have remained
        /// unmodified 
        /// </summary>
        public DateTimeOffset? IfUnmodifiedSince { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that have a matching ETag.
        /// </summary>
        public ETag? IfMatch { get; set; }

        /// <summary>
        /// Optionally limit requests to resources that do not match the ETag.
        /// </summary>
        public ETag? IfNoneMatch { get; set; }

        /// <summary>
        /// Check if two HttpAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is HttpAccessConditions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the HttpAccessConditions.
        /// </summary>
        /// <returns>Hash code for the HttpAccessConditions.</returns>
        public override int GetHashCode()
            => this.IfModifiedSince.GetHashCode()
            ^ this.IfUnmodifiedSince.GetHashCode()
            ^ this.IfMatch.GetHashCode()
            ^ this.IfNoneMatch.GetHashCode()
            ;

        /// <summary>
        /// Check if two HttpAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(HttpAccessConditions left, HttpAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two HttpAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(HttpAccessConditions left, HttpAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two HttpAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(HttpAccessConditions other)
            => this.IfMatch == other.IfMatch
            && this.IfModifiedSince == other.IfModifiedSince
            && this.IfNoneMatch == other.IfNoneMatch
            && this.IfUnmodifiedSince == other.IfUnmodifiedSince
            ;

        /// <summary>
        /// Converts the value of the current HttpAccessConditions object to
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the HttpAccessConditions.
        /// </returns>
        public override string ToString() 
            => $"[{nameof(HttpAccessConditions)}:{nameof(this.IfModifiedSince)}={this.IfModifiedSince};{nameof(this.IfUnmodifiedSince)}={this.IfUnmodifiedSince};{nameof(this.IfMatch)}={this.IfMatch};{nameof(this.IfNoneMatch)}={this.IfNoneMatch}]";
    }

    /// <summary>
    /// Specifies blob container specific access conditions.
    /// </summary>
    public struct ContainerAccessConditions : IEquatable<ContainerAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies container lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }

        /// <summary>
        /// Check if two ContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is ContainerAccessConditions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the ContainerAccessConditions.
        /// </summary>
        /// <returns>Hash code for the ContainerAccessConditions.</returns>
        public override int GetHashCode()
            => this.HttpAccessConditions.GetHashCode()
            ^ this.LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two ContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(ContainerAccessConditions left, ContainerAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two ContainerAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(ContainerAccessConditions left, ContainerAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two ContainerAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(ContainerAccessConditions other)
            => this.HttpAccessConditions == other.HttpAccessConditions
            && this.LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current ContainerAccessConditions object
        /// to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the ContainerAccessConditions.
        /// </returns>
        public override string ToString() 
            => $"[{nameof(ContainerAccessConditions)}:{nameof(this.HttpAccessConditions)}={this.HttpAccessConditions};{nameof(this.LeaseAccessConditions)}={this.LeaseAccessConditions}]";
    }

    /// <summary>
    /// Specifies blob specific access conditions.
    /// </summary>
    public struct BlobAccessConditions : IEquatable<BlobAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies blob lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }

        /// <summary>
        /// Check if two BlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is BlobAccessConditions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobAccessConditions.
        /// </summary>
        public override int GetHashCode()
            => this.HttpAccessConditions.GetHashCode()
            ^ this.LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two BlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobAccessConditions left, BlobAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobAccessConditions left, BlobAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two BlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobAccessConditions other)
            => this.HttpAccessConditions == other.HttpAccessConditions
            && this.LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current BlobAccessConditions object to 
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the BlobAccessConditions.
        /// </returns>
        public override string ToString() 
            => $"[{nameof(BlobAccessConditions)}:{nameof(this.HttpAccessConditions)}={this.HttpAccessConditions};{nameof(this.LeaseAccessConditions)}={this.LeaseAccessConditions}]";
    }

    /// <summary>
    /// Specifies blob lease access conditions for a container or blob.
    /// </summary>
    public struct LeaseAccessConditions : IEquatable<LeaseAccessConditions>
    {
        /// <summary>
        /// Optionally limit requests to resources with an active lease
        /// matching this Id.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Check if two LeaseAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is LeaseAccessConditions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the LeaseAccessConditions.
        /// </summary>
        /// <returns>Hash code for the LeaseAccessConditions.</returns>
        public override int GetHashCode()
            => this.LeaseId.GetHashCode();

        /// <summary>
        /// Check if two LeaseAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(LeaseAccessConditions left, LeaseAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two LeaseAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(LeaseAccessConditions left, LeaseAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two LeaseAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(LeaseAccessConditions other)
            => this.LeaseId == other.LeaseId;

        /// <summary>
        /// Converts the value of the current HttpAccessConditions object to 
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the HttpAccessConditions.
        /// </returns>
        public override string ToString() 
            => $"[{nameof(LeaseAccessConditions)}:{nameof(this.LeaseId)}={this.LeaseId}]";
    }

    /// <summary>
    /// Specifies append blob specific access conditions.
    /// </summary>
    public struct AppendBlobAccessConditions : IEquatable<AppendBlobAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies blob lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }
        
        /// <summary>
        /// IfAppendPositionEqual ensures that the AppendBlock operation
        /// succeeds only if the append position is equal to a value.
        /// </summary>
        public long? IfAppendPositionEqual { get; set; }

        /// <summary>
        /// IfMaxSizeLessThanOrEqual ensures that the AppendBlock operation
        /// succeeds only if the append blob's size is less than or equal to
        /// a value.
        /// </summary>
        public long? IfMaxSizeLessThanOrEqual { get; set; }

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is AppendBlobAccessConditions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the AppendBlobAccessConditions.
        /// </summary>
        /// <returns>Hash code for the AppendBlobAccessConditions.</returns>
        public override int GetHashCode()
            => this.HttpAccessConditions.GetHashCode()
            ^ this.IfAppendPositionEqual.GetHashCode()
            ^ this.IfMaxSizeLessThanOrEqual.GetHashCode()
            ^ this.LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(AppendBlobAccessConditions left, AppendBlobAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(AppendBlobAccessConditions left, AppendBlobAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two AppendBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(AppendBlobAccessConditions other)
            => this.HttpAccessConditions == other.HttpAccessConditions
            && this.IfAppendPositionEqual == other.IfAppendPositionEqual
            && this.IfMaxSizeLessThanOrEqual == other.IfMaxSizeLessThanOrEqual
            && this.LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current AppendBlobAccessConditions 
        /// object to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the AppendBlobAccessConditions.
        /// </returns>
        public override string ToString() 
            => $"[{nameof(AppendBlobAccessConditions)}:{nameof(this.HttpAccessConditions)}={this.HttpAccessConditions};{nameof(this.LeaseAccessConditions)}={this.LeaseAccessConditions};{nameof(this.IfAppendPositionEqual)}={this.IfAppendPositionEqual};{nameof(this.IfMaxSizeLessThanOrEqual)}={this.IfMaxSizeLessThanOrEqual}]";
    }

    /// <summary>
    /// Specifies page blob specific access conditions.
    /// </summary>
    public struct PageBlobAccessConditions : IEquatable<PageBlobAccessConditions>
    {
        /// <summary>
        /// Specifies standard HTTP access conditions.
        /// </summary>
        public HttpAccessConditions? HttpAccessConditions { get; set; }

        /// <summary>
        /// Specifies blob lease access conditions.
        /// </summary>
        public LeaseAccessConditions? LeaseAccessConditions { get; set; }

        /// <summary>
        /// IfSequenceNumberLessThan ensures that the page blob operation
        /// succeeds only if the blob's sequence number is less than a value.
        /// </summary>
        public long? IfSequenceNumberLessThan { get; set; }

        /// <summary>
        /// IfSequenceNumberLessThanOrEqual ensures that the page blob
        /// operation succeeds only if the blob's sequence number is less than
        /// or equal to a value.
        /// </summary>
        public long? IfSequenceNumberLessThanOrEqual { get; set; }

        /// <summary>
        /// IfSequenceNumberEqual ensures that the page blob operation
        /// succeeds only if the blob's sequence number is equal to a value.
        /// </summary>
        public long? IfSequenceNumberEqual { get; set; }

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is PageBlobAccessConditions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the PageBlobAccessConditions.
        /// </summary>
        /// <returns>Hash code for the PageBlobAccessConditions.</returns>
        public override int GetHashCode()
            => this.HttpAccessConditions.GetHashCode()
            ^ this.IfSequenceNumberEqual.GetHashCode()
            ^ this.IfSequenceNumberLessThan.GetHashCode()
            ^ this.IfSequenceNumberLessThanOrEqual.GetHashCode()
            ^ this.LeaseAccessConditions.GetHashCode()
            ;

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(PageBlobAccessConditions left, PageBlobAccessConditions right) => left.Equals(right);

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(PageBlobAccessConditions left, PageBlobAccessConditions right) => !(left == right);

        /// <summary>
        /// Check if two PageBlobAccessConditions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(PageBlobAccessConditions other)
            => this.HttpAccessConditions == other.HttpAccessConditions
            && this.IfSequenceNumberEqual == other.IfSequenceNumberEqual
            && this.IfSequenceNumberLessThan == other.IfSequenceNumberLessThan
            && this.IfSequenceNumberLessThanOrEqual == other.IfSequenceNumberLessThanOrEqual
            && this.LeaseAccessConditions == other.LeaseAccessConditions
            ;

        /// <summary>
        /// Converts the value of the current PageBlobAccessConditions object 
        /// to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the PageBlobAccessConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(PageBlobAccessConditions)}:{nameof(this.HttpAccessConditions)}={this.HttpAccessConditions};{nameof(this.LeaseAccessConditions)}={this.LeaseAccessConditions};{nameof(this.IfSequenceNumberLessThan)}={this.IfSequenceNumberLessThan};{nameof(this.IfSequenceNumberLessThanOrEqual)}={this.IfSequenceNumberLessThanOrEqual};{nameof(this.IfSequenceNumberEqual)}={this.IfSequenceNumberEqual}]";
    }
}
