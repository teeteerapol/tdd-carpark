using CarPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarPark.Facts
{
    public class TicketFacts
    {
        public class General
        {
            [Fact]
            public void BasicUsage()
            {
                // arrange
                Ticket t;
                t = new Ticket();
                t.PlateNo = "1707";
                t.DateIn = new DateTime(2016, 1, 1, 9, 0, 0);
                t.DateOut = DateTime.Parse("13:30");

                // act

                // assert
                Assert.Equal("1707", t.PlateNo);
                Assert.Equal(9, t.DateIn.Hour);
                Assert.Equal(13, t.DateOut.GetValueOrDefault().Hour);
            }
        }

        public class ParkingFeeProperty
        {
            [Fact]
            public void First15Minutes_Free()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("9:15");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(0m, fee);
            }

            [Fact]
            public void WithInfirst3Hour_50Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("9:15:01");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(50m, fee);
            }

            [Fact]
            public void WithInfirst3Hour11_50Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("12:11");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(50m, fee);
            }

            [Fact]
            public void For4Hour_80Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("13:00");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(80m, fee);
            }

            [Fact]
            public void For6Hour_140Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("15:00");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(140m, fee);
            }

            [Fact]
            public void For6Hour12_140Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("15:12");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(140m, fee);
            }

            [Fact]
            public void For6Hour16_140Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("15:16");

                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(170m, fee);
            }

            [Fact]
            public void For6HourExceed15Minutes_140Baht()
            {
                // arrange
                var t = new Ticket();
                t.DateIn = DateTime.Parse("9:00");
                t.DateOut = DateTime.Parse("15:15:01");
              
                // act
                Decimal fee = t.ParkingFee;

                // assert
                Assert.Equal(170m, fee);
            }
        }
    }
}
