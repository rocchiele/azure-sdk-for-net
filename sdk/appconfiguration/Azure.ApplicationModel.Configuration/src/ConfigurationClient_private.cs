﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ApplicationModel.Configuration
{
    public partial class ConfigurationClient
    {
        const string AcceptDateTimeFormat = "R";
        const string AcceptDatetimeHeader = "Accept-Datetime";
        const string KvRoute = "/kv/";
        const string RevisionsRoute = "/revisions/";
        const string KeyQueryFilter = "key";
        const string LabelQueryFilter = "label";
        const string FieldsQueryFilter = "$select";
        const string IfMatchName = "If-Match";
        const string IfNoneMatch = "If-None-Match";

        static readonly char[] ReservedCharacters = new char[] { ',', '\\' };

        static readonly HttpHeader MediaTypeKeyValueApplicationHeader = new HttpHeader(
            HttpHeader.Names.Accept,
            "application/vnd.microsoft.appconfig.kv+json"
        );

        static async Task<Response<ConfigurationSetting>> CreateResponseAsync(Response response, CancellationToken cancellation)
        {
            ConfigurationSetting result = await ConfigurationServiceSerializer.DeserializeSettingAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return new Response<ConfigurationSetting>(response, result);
        }

        static Response<ConfigurationSetting> CreateResponse(Response response)
        {
            return new Response<ConfigurationSetting>(response, ConfigurationServiceSerializer.DeserializeSetting(response.ContentStream));
        }

        static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            Debug.Assert(connectionString != null); // callers check this

            uri = default;
            credential = default;
            secret = default;

            // Parse connection string
            string[] args = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 3)
            {
                throw new ArgumentException("invalid connection string segment count", nameof(connectionString));
            }

            const string endpointString = "Endpoint=";
            const string idString = "Id=";
            const string secretString = "Secret=";

            // TODO (pri 2): this allows elements in the connection string to be in varied order. Should we disallow it?
            // TODO (pri 2): this parser will succeed even if one of the elements is missing (e.g. if cs == "a;b;c". We should fix that.
            foreach (var arg in args)
            {
                var segment = arg.Trim();
                if (segment.StartsWith(endpointString, StringComparison.OrdinalIgnoreCase))
                {
                    uri = new Uri(segment.Substring(segment.IndexOf('=') + 1));
                }
                else if (segment.StartsWith(idString, StringComparison.OrdinalIgnoreCase))
                {
                    credential = segment.Substring(segment.IndexOf('=') + 1);
                }
                else if (segment.StartsWith(secretString, StringComparison.OrdinalIgnoreCase))
                {
                    var secretBase64 = segment.Substring(segment.IndexOf('=') + 1);
                    // TODO (pri 2): this might throw an obscure exception. Should we throw a consisten exception when the parser fails?
                    secret = Convert.FromBase64String(secretBase64);
                }
            };
        }

        void BuildUriForKvRoute(RequestUriBuilder builder, ConfigurationSetting keyValue)
            => BuildUriForKvRoute(builder, keyValue.Key, keyValue.Label); // TODO (pri 2) : does this need to filter ETag?

        void BuildUriForKvRoute(RequestUriBuilder builder, string key, string label)
        {
            builder.Uri = _baseUri;
            builder.AppendPath(KvRoute);
            builder.AppendPath(key);

            if (label != null)
            {
                builder.AppendQuery(LabelQueryFilter, label);
            }
        }

        private static string EscapeReservedCharacters(string input)
        {
            string resp = string.Empty;
            for (int i=0; i<input.Length; i++)
            {
                if (ReservedCharacters.Contains(input[i]))
                {
                    resp += $"\\{input[i]}";
                }
                else
                {
                    resp += input[i];
                }
            }
            return resp;
        }

        internal static void BuildBatchQuery(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            if (selector.Keys.Count > 0)
            {
                var keysCopy = new List<string>();
                foreach (var key in selector.Keys)
                {
                    if (key.IndexOfAny(ReservedCharacters) != -1)
                    {
                        keysCopy.Add(EscapeReservedCharacters(key));
                    }
                    else
                    {
                        keysCopy.Add(key);
                    }
                }
                var keys = string.Join(",", keysCopy);
                builder.AppendQuery(KeyQueryFilter, keys);
            }

            if (selector.Labels.Count > 0)
            {
                var labelsCopy = new List<string>();
                foreach (var label in selector.Labels)
                {
                    if (string.IsNullOrEmpty(label))
                    {
                        labelsCopy.Add("\0");
                    }
                    else
                    {
                        labelsCopy.Add(EscapeReservedCharacters(label));
                    }
                }
                var labels = string.Join(",", labelsCopy);
                builder.AppendQuery(LabelQueryFilter, labels);
            }

            if (selector.Fields != SettingFields.All)
            {
                var filter = selector.Fields.ToString().ToLowerInvariant();
                builder.AppendQuery(FieldsQueryFilter, filter);
            }

            if (!string.IsNullOrEmpty(pageLink))
            {
                builder.AppendQuery("after", pageLink);
            }
        }

        void BuildUriForGetBatch(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Uri = _baseUri;
            builder.AppendPath(KvRoute);
            BuildBatchQuery(builder, selector, pageLink);
        }

        void BuildUriForRevisions(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Uri = _baseUri;
            builder.AppendPath(RevisionsRoute);
            BuildBatchQuery(builder, selector, pageLink);
        }

        static ReadOnlyMemory<byte> Serialize(ConfigurationSetting setting)
        {
            var writer = new ArrayBufferWriter<byte>();
            ConfigurationServiceSerializer.Serialize(setting, writer);
            return writer.WrittenMemory;
        }
        #region nobody wants to see these
        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the ConfigurationSetting
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Creates a Key Value string in reference to the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
