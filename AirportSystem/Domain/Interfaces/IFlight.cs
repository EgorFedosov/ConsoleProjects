using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IFlight
{
    IAirplane Airplane { get; }
    IReadOnlyCollection<IPilot> Crew { get; }
    IReadOnlyCollection<IPassenger> Passengers { get; }
    Route Route { get; }
    Money TicketPrice { get; }

    void AddPassenger(IPassenger passenger);
    void UpdateTicketPrice(Money newPrice);
}