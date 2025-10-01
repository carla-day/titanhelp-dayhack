using System.ComponentModel.DataAnnotations;

namespace TitanHelpDesk.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string ProblemDescription { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)]
        public TicketStatus Status { get; set; } = TicketStatus.Open;

        [Required]
        [MaxLength(10)]
        public PriorityLevel Priority { get; set; } = PriorityLevel.Low; 
    }
}
