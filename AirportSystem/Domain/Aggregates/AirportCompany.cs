using System.Collections.ObjectModel;
using AirportSystem.Domain.Interfaces;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Aggregates;

public class AirportCompany(Money initialBalance) : IAirportCompany
{
    private readonly List<IAirplane> _airplanes = [];
    private readonly List<IPilot> _staff = [];
    private readonly List<IFlight> _flights = [];

    public ReadOnlyCollection<IAirplane> Airplanes => _airplanes.AsReadOnly();
    public ReadOnlyCollection<IPilot> Staff => _staff.AsReadOnly();
    public ReadOnlyCollection<IFlight> Flights => _flights.AsReadOnly();
    public Money Balance { get; private set; } = initialBalance;

    public void AddAirplane(IAirplane airplane)
    {
        ArgumentNullException.ThrowIfNull(airplane);
        _airplanes.Add(airplane);
    }

    public void AddPilot(IPilot pilot)
    {
        ArgumentNullException.ThrowIfNull(pilot);
        _staff.Add(pilot);
    }

    public void AddFlight(IFlight flight)
    {
        ArgumentNullException.ThrowIfNull(flight);
        _flights.Add(flight);
    }

    public void AddBalance(Money amount)
    {
        ArgumentNullException.ThrowIfNull(amount);
        Balance += amount;
    }

    public void PrintAllFlights()
    {
        foreach (var flight in _flights)
            flight.Print();
    }
    public IFlight? FindFlightById(Guid flightId)
        => _flights.FirstOrDefault(f => f.FlightId == flightId);
}