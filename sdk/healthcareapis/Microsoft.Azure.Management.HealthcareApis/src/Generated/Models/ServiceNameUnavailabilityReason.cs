// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.HealthcareApis.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ServiceNameUnavailabilityReason.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceNameUnavailabilityReason
    {
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "AlreadyExists")]
        AlreadyExists
    }
    internal static class ServiceNameUnavailabilityReasonEnumExtension
    {
        internal static string ToSerializedValue(this ServiceNameUnavailabilityReason? value)
        {
            return value == null ? null : ((ServiceNameUnavailabilityReason)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this ServiceNameUnavailabilityReason value)
        {
            switch( value )
            {
                case ServiceNameUnavailabilityReason.Invalid:
                    return "Invalid";
                case ServiceNameUnavailabilityReason.AlreadyExists:
                    return "AlreadyExists";
            }
            return null;
        }

        internal static ServiceNameUnavailabilityReason? ParseServiceNameUnavailabilityReason(this string value)
        {
            switch( value )
            {
                case "Invalid":
                    return ServiceNameUnavailabilityReason.Invalid;
                case "AlreadyExists":
                    return ServiceNameUnavailabilityReason.AlreadyExists;
            }
            return null;
        }
    }
}
