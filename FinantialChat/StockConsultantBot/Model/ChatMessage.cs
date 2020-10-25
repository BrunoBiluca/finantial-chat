using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockConsultantBot {
    public class ChatMessage {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("message")]
        [Required]
        public string Message { get; set; }

        [Required]
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [JsonPropertyName("user")]
        [Required]
        public string UserName { get; set; }

    }
}
