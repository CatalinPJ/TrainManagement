using Data.Domain.Entities;
using FluentAssertions;
using Xunit;
using Services;
namespace UnitTests
{
    public class EntitiesTests
    {
        [Fact]
        public void Given_Train_Then_IdShouldNotBeNull()
        {
            var train = new Train();
            train.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Given_Station_Then_IdShouldNotBeNull()
        {
            var station = new Station();
            station.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Given_Ticket_Then_IdShouldNotBeNull()
        {
            var ticket = new Ticket();
            ticket.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Given_RouteNode_Then_IdShouldNotBeNull()
        {
            var routeNode = new RouteNode();
            routeNode.Id.Should().NotBeEmpty();
        }
    }
}
