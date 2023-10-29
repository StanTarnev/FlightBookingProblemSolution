namespace FlightBooking.Core.Tests;

using FlightBooking.Core;

public class PassengerTest
{
    Passenger passenger = new Passenger 
    {
        Type = PassengerType.LoyaltyMember,
        Name = "John",
        Age = 29,
        LoyaltyPoints = 1000,
        IsUsingLoyaltyPoints = true
    };

    [Fact]
    public void hasType()
    {
        Assert.Equal(PassengerType.LoyaltyMember, passenger.Type);
    }

    [Fact]
    public void HasName()
    {
        Assert.Equal("John", passenger.Name);
    }

    [Fact]
    public void HasAge()
    {
        Assert.Equal(29, passenger.Age);
    }

    [Fact]
    public void HasLoyaltyPoints()
    {
        Assert.Equal(1000, passenger.LoyaltyPoints);
    }

    [Fact]
    public void IsUsingLoyaltyPoints()
    {
        Assert.True(passenger.IsUsingLoyaltyPoints);
    }
}