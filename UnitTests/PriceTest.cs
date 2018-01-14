using FluentAssertions;
using Xunit;
using Data.Domain.Entities;
using Services;

namespace UnitTests
{
    class PriceTest
    {
        [Fact]
        public void Given_Ticket_ResultPrice_ShouldBe_TheSame()
        {
            var ticket = new Ticket();
            var result = new PriceComputer();
            ticket.Adults = 2;
            ticket.Km = 400;
            ticket.Children = 1;
            ticket.Pet = 1;
            ticket.TrainCategory = "IR";
            ticket.Class = 1;
            var price = 323.4f;
            var resultprice = result.GetPrice(ticket);
            resultprice.ShouldBeEquivalentTo(price);
        }
    }
}
