using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IFlight
{
    IAirplane Airplane { get; }
    List<IPerson> Crew { get; }
    List<IPassenger> Passengers { get; }
    Route Route { get; }
    Money TicketPrice { get; }
}