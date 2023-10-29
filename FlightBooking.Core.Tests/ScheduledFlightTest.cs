namespace FlightBooking.Core.Tests;

using FlightBooking.Core;

public class ScheduledFlightTest
{
    private FlightRoute _londonToParis;
    private ScheduledFlight _scheduledFlight;
    private Passenger _passenger1;
    private Passenger _passenger2;
    private Plane _plane;
    private Plane _backUpPlane1;

    public ScheduledFlightTest()
    {
        _londonToParis = new FlightRoute("London", "Paris")
        {
            BaseCost = 50,
            BasePrice = 100,
            LoyaltyPointsGained = 5,
            MinimumTakeOffPercentage = 0.7
        };
        _scheduledFlight = new ScheduledFlight(_londonToParis);
        _passenger1 = new Passenger 
        {
            Type = PassengerType.LoyaltyMember,
            Name = "John",
            Age = 29,
            LoyaltyPoints = 1000,
            IsUsingLoyaltyPoints = true
        };
        _passenger2 = new Passenger 
        {
            Type = PassengerType.AirlineEmployee,
            Name = "Trevor",
            Age = 47
        };
        _plane = new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 };
        _backUpPlane1 = new Plane { Id = 124, Name = "Antonov AN-124", NumberOfSeats = 88 };
    }

    [Fact]
    public void HasFlightRoute()
    {
        Assert.Equal(_londonToParis, _scheduledFlight.FlightRoute);
    }

    [Fact]
    public void AircraftIsInitiallyNull()
    {
        Assert.Null(_scheduledFlight.Aircraft);
    }

    [Fact]
    public void PassengerListIsInitiallyEmpty()
    {
        Assert.Empty(_scheduledFlight.Passengers);
    }

    [Fact]
    public void BackUpPlanesListIsInitiallyEmpty()
    {
        Assert.Empty(_scheduledFlight.BackUpPlanes);
    }

    [Fact]
    public void CanAddBackUpPlane()
    {
        _scheduledFlight.AddBackUpPlane(_backUpPlane1);
        Assert.Single(_scheduledFlight.BackUpPlanes);
    }

    [Fact]
    public void CheckBackUpPlaneWithEnoughSeatsAvailable__True()
    {
        _scheduledFlight.AddBackUpPlane(_backUpPlane1);
        _scheduledFlight.SetAircraftForRoute(_plane);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        Assert.NotEmpty(_scheduledFlight.BackUpPlaneWithEnoughSeatsAvailable());
    }

    [Fact]
    public void CheckBackUpPlaneWithEnoughSeatsAvailable__False()
    {
        _scheduledFlight.SetAircraftForRoute(_plane);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger1);
        Assert.Empty(_scheduledFlight.BackUpPlaneWithEnoughSeatsAvailable());
    }

    [Fact]
    public void HasDefaultRuleSet()
    {
        Assert.Equal(RuleSetType.Default, _scheduledFlight.RuleSetType);
    }

    [Fact]
    public void CanChangeRuleSetType()
    {
        _scheduledFlight.SetRuleSetType(RuleSetType.Relaxed);
        Assert.Equal(RuleSetType.Relaxed, _scheduledFlight.RuleSetType);
    }

    [Fact]
    public void CanAddPassenger()
    {
        _scheduledFlight.AddPassenger(_passenger1);
        Assert.Single(_scheduledFlight.Passengers);
    }

    [Fact]
    public void CanCountEmployeePassengers()
    {
        _scheduledFlight.AddPassenger(_passenger1);
        _scheduledFlight.AddPassenger(_passenger2);
        Assert.Equal(1, _scheduledFlight.CountEmployeePassengers());
    }

    [Fact]
    public void CanSetAircraftForRoute()
    {
        _scheduledFlight.SetAircraftForRoute(_plane);
        Assert.NotNull(_scheduledFlight.Aircraft);
    }

    [Fact]
    public void CheckEmployeePassengersMoreThanMinimumPercentage__True()
    {
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        Assert.True(_scheduledFlight.EmployeePassengersMoreThanMinimumPercentage());
    }

    [Fact]
    public void CheckEmployeePassengersMoreThanMinimumPercentage__False()
    {
        _scheduledFlight.AddPassenger(_passenger2);
        _scheduledFlight.AddPassenger(_passenger2);
        Assert.False(_scheduledFlight.EmployeePassengersMoreThanMinimumPercentage());
    }
}