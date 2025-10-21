using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AfleveringM404.Models
{
    public class SupportMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int TicketId { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public string Description {  get; set; } = string.Empty;
        [Required]
        public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
