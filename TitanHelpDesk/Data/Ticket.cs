using System.ComponentModel.DataAnnotations;

namespace TitanHelpDesk.Data
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required, StringLength(1000)]
        public string ProblemDescription { get; set; } = string.Empty;

        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public PriorityLevel Priority { get; set; } = PriorityLevel.Low;
    }

}
