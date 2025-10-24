using AirportSystem.Domain.Interfaces;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Aggregates;

public class Flight(IAirplane airplane, List<IPilot> crew, Route route, Money ticketPrice) : IFlight
{
    private readonly List<IPilot> _crew = [];
    private readonly List<IPassenger> _passengers = [];

    public IAirplane Airplane { get; } = airplane;
    public IReadOnlyCollection<IPilot> Crew => _crew.AsReadOnly();
    public IReadOnlyCollection<IPassenger> Passengers => _passengers.AsReadOnly();
    public Route Route { get; } = route;
    public Money TicketPrice { get; private set; } = ticketPrice;

    public void AddPassenger(IPassenger passenger)
    {
        if (_passengers.Count >= Airplane.Capacity) return;
        _passengers.Add(passenger);
    }

    public void UpdateTicketPrice(Money newPrice)
    {
        if (newPrice == TicketPrice) return;
        TicketPrice = newPrice;
    }
}