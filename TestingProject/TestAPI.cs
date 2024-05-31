using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyAppT.Controllers;
using MyAppT.Infrastructure;
using MyAppT.Models;
using Xunit;

namespace TestingProject
{
    public class TestAPI
    {
        [Fact]
        public void Test_GET_AllReservations()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.Reservations).Returns(Multiple());
            var controller = new ReservationController(mockRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Reservation>>(result);
            Assert.Equal(3, model.Count());
        }

        private static IEnumerable<Reservation> Multiple()
        {
            var r = new List<Reservation>
            {
                new Reservation()
                {
                    Id = 1,
                    Name = "Test One",
                    StartLocation = "SL1",
                    EndLocation = "EL1"
                },
                new Reservation()
                {
                    Id = 2,
                    Name = "Test Two",
                    StartLocation = "SL2",
                    EndLocation = "EL2"
                },
                new Reservation()
                {
                    Id = 3,
                    Name = "Test Three",
                    StartLocation = "SL3",
                    EndLocation = "EL3"
                }
            };
            return r;
        }

    }
}
