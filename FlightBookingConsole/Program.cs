using System;
using FlightBooking.Core;

namespace FlightBookingProblem
{
    class Program
    {
        private static ScheduledFlight _scheduledFlight;

        static void Main(string[] args)
        {
            SetupAirlineData();

            Console.WriteLine("Which business rules should apply for the flight: Default or Relaxed?");
            var rulesChoice = Console.ReadLine().ToLower();
            while (rulesChoice != "default" && rulesChoice != "relaxed")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UNKNOWN INPUT. PLEASE TYPE IN YOUR RULES CHOICE!");
                Console.ResetColor();
                rulesChoice = Console.ReadLine().ToLower();
            }

            if (rulesChoice == "relaxed")
            {
                _scheduledFlight.SetRuleSetType(RuleSetType.Relaxed);
            }

            Console.WriteLine("");
            // Console.WriteLine($"Business rules for the flight set to: {char.ToUpper(rulesChoice[0]) + rulesChoice.Substring(1)}.");
            Console.WriteLine($"Business rules for the flight set to: {_scheduledFlight.RuleSetType}.");

            Console.WriteLine("");
            Console.WriteLine("What else do you want to do?");
            
            string command = "";
            do
            {
                command = Console.ReadLine() ?? "";
                var enteredText = command.ToLower();

                if (enteredText.Contains("print summary"))
                {
                    Console.WriteLine();
                    Console.WriteLine(_scheduledFlight.GetSummary());
                }
                else if (enteredText.Contains("add general"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.General, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3])
                    });
                }
                else if (enteredText.Contains("add loyalty"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.LoyaltyMember, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                        LoyaltyPoints = Convert.ToInt32(passengerSegments[4]),
                        IsUsingLoyaltyPoints = Convert.ToBoolean(passengerSegments[5]),
                    });
                }
                else if (enteredText.Contains("add airline"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.AirlineEmployee, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("add discounted"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddPassenger(new Passenger
                    {
                        Type = PassengerType.Discounted, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("add plane"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    _scheduledFlight.AddBackUpPlane(new Plane
                    {
                        Id = Convert.ToInt32(passengerSegments[2]), 
                        Name = passengerSegments[3], 
                        NumberOfSeats = Convert.ToInt32(passengerSegments[4])
                    });
                }
                else if (enteredText.Contains("exit"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UNKNOWN INPUT");
                    Console.ResetColor();
                }
            } while (command != "exit");
        }

        private static void SetupAirlineData()
        {
            FlightRoute londonToParis = new FlightRoute("London", "Paris")
            {
                BaseCost = 50, 
                BasePrice = 100, 
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            _scheduledFlight = new ScheduledFlight(londonToParis);

            _scheduledFlight.SetAircraftForRoute(
                new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });
        }
    }
}
