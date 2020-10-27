using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class TimestampConverter : JsonConverter<DateTime> {
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(reader.GetDouble());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
        writer.WriteNumberValue((
            TimeZoneInfo.ConvertTimeToUtc(value) 
            - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
        ).TotalMilliseconds);
    }
}
