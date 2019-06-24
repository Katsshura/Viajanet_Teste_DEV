using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace RabbitMQ.Robot.Domain
{
    internal static class JsonSettings
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
