namespace FlightBooking.Core.Tests;

using FlightBooking.Core;

public class FlightRouteTest
{
    FlightRoute londonToParis = new FlightRoute("London", "Paris")
    {
        BaseCost = 50,
        BasePrice = 100,
        LoyaltyPointsGained = 5,
        MinimumTakeOffPercentage = 0.7
    };

    [Fact]
    public void HasTitle()
    {
        Assert.Equal("London to Paris", londonToParis.Title);
    }

    [Fact]
    public void HasBaseCost()
    {
        Assert.Equal(50, londonToParis.BaseCost);
    }

    [Fact]
    public void HasBasePrice()
    {
        Assert.Equal(100, londonToParis.BasePrice);
    }

    [Fact]
    public void HasLoyaltyPointsGained()
    {
        Assert.Equal(5, londonToParis.LoyaltyPointsGained);
    }

    [Fact]
    public void HasMinimumTakeOffPercentage()
    {
        Assert.Equal(0.7, londonToParis.MinimumTakeOffPercentage);
    }
}