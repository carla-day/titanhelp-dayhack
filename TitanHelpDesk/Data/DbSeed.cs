using Microsoft.EntityFrameworkCore;

namespace TitanHelpDesk.Data
{
    public static class DbSeed
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            if (await db.Tickets.AnyAsync()) return;

            db.Tickets.AddRange(
                new Ticket { Name = "Printer issue", ProblemDescription = "Jams on page 2", Priority = PriorityLevel.Medium, Status = TicketStatus.Open },
                new Ticket { Name = "Email down", ProblemDescription = "Outlook can’t connect", Priority = PriorityLevel.High, Status = TicketStatus.InProgress }
            );
            await db.SaveChangesAsync();
        }
    }
}
