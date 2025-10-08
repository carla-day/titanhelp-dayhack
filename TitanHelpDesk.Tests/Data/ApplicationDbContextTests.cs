using Microsoft.EntityFrameworkCore;
using TitanHelpDesk.Data;

[TestClass]
public class ApplicationDbContextTests
{
    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;
        return new ApplicationDbContext(options);
    }

    [TestMethod]
    public void Can_Add_And_Retrieve_Ticket()
    {
        using var db = GetDbContext();
        var t = new Ticket { Name = "Test", ProblemDescription = "Desc" };
        db.Tickets.Add(t);
        db.SaveChanges();

        var retrieved = db.Tickets.FirstOrDefault(x => x.Name == "Test");
        Assert.IsNotNull(retrieved);
        Assert.AreEqual("Desc", retrieved.ProblemDescription);
    }

    [TestMethod]
    public void Can_Delete_Ticket()
    {
        using var db = GetDbContext();
        var t = new Ticket { Name = "DeleteMe", ProblemDescription = "Temp" };
        db.Tickets.Add(t);
        db.SaveChanges();

        db.Tickets.Remove(t);
        db.SaveChanges();

        Assert.IsNull(db.Tickets.FirstOrDefault(x => x.Name == "DeleteMe"));
    }
}
