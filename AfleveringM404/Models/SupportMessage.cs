using System.ComponentModel.DataAnnotations;

namespace AfleveringM404.Models
{
    public class SupportMessage
    {
        public int TicketID { get; set; }
        [Required]
        public Contact Contact { get; set; }
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public string Description {  get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; init; } = DateTime.Now;

        public SupportMessage(Contact contact, string category, string description)
        {
            Contact = new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone
            };
            Category = category;
            Description = description;
        }
    }
}
