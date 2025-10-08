using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TitanHelpDesk.Data;

namespace TitanHelpDesk.Tests.Data
{
    [TestClass]
    public class TicketTests
    {
        private static IList<ValidationResult> Validate(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }

        private static string MakeString(int length) => new string('x', length);

        [TestMethod]
        public void Ticket_Defaults_Are_Set()
        {
            var before = DateTime.UtcNow.AddSeconds(-2);
            var t = new Ticket(); // uses defaults
            var after = DateTime.UtcNow.AddSeconds(2);

            Assert.AreEqual(TicketStatus.Open, t.Status, "Default Status should be Open.");
            Assert.AreEqual(PriorityLevel.Low, t.Priority, "Default Priority should be Low.");
            Assert.IsTrue(t.Date >= before && t.Date <= after, "Default Date should be ~UtcNow.");
            Assert.AreEqual(string.Empty, t.Name);
            Assert.AreEqual(string.Empty, t.ProblemDescription);
        }

        [TestMethod]
        public void Ticket_Valid_Model_Passes_Validation()
        {
            var t = new Ticket
            {
                Name = "Printer issue",
                ProblemDescription = "The office printer is jamming on every third page.",
                Priority = PriorityLevel.Medium,
                Status = TicketStatus.InProgress,
                Date = DateTime.UtcNow
            };

            var results = Validate(t);

            Assert.AreEqual(0, results.Count, "Expected no validation errors for a valid ticket.");
        }

        [TestMethod]
        public void Ticket_Name_Required()
        {
            var t = new Ticket
            {
                Name = "",
                ProblemDescription = "Something broke."
            };

            var results = Validate(t);

            Assert.IsTrue(results.Any(r => r.MemberNames.Contains(nameof(Ticket.Name))),
                "Name should be required.");
        }

        [TestMethod]
        public void Ticket_ProblemDescription_Required()
        {
            var t = new Ticket
            {
                Name = "Network issue",
                ProblemDescription = ""
            };

            var results = Validate(t);

            Assert.IsTrue(results.Any(r => r.MemberNames.Contains(nameof(Ticket.ProblemDescription))),
                "ProblemDescription should be required.");
        }

        [TestMethod]
        public void Ticket_Name_MaxLength_100()
        {
            var t = new Ticket
            {
                Name = MakeString(101),
                ProblemDescription = "Valid"
            };

            var results = Validate(t);

            Assert.IsTrue(results.Any(r => r.MemberNames.Contains(nameof(Ticket.Name))),
                "Name should have [StringLength(100)].");
        }

        [TestMethod]
        public void Ticket_ProblemDescription_MaxLength_1000()
        {
            var t = new Ticket
            {
                Name = "Valid",
                ProblemDescription = MakeString(1001)
            };

            var results = Validate(t);

            Assert.IsTrue(results.Any(r => r.MemberNames.Contains(nameof(Ticket.ProblemDescription))),
                "ProblemDescription should have [StringLength(1000)].");
        }

        [TestMethod]
        public void TicketStatus_Enum_Values_Are_Stable()
        {
            Assert.AreEqual(0, (int)TicketStatus.Open);
            Assert.AreEqual(1, (int)TicketStatus.InProgress);
            Assert.AreEqual(2, (int)TicketStatus.Closed);
        }

        [TestMethod]
        public void PriorityLevel_Enum_Values_Are_Stable()
        {
            Assert.AreEqual(0, (int)PriorityLevel.Low);
            Assert.AreEqual(1, (int)PriorityLevel.Medium);
            Assert.AreEqual(2, (int)PriorityLevel.High);
        }
    }
}
