namespace FlightBooking.Core.Tests;

using FlightBooking.Core;

public class PlaneTest
{
    
    Plane plane = new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 };

    [Fact]
    public void HasId()
    {
        Assert.Equal(123, plane.Id);
    }

    [Fact]
    public void HasName()
    {
        Assert.Equal("Antonov AN-2", plane.Name);
    }

    [Fact]
    public void HasNumberOfSeats()
    {
        Assert.Equal(12, plane.NumberOfSeats);
    }
}