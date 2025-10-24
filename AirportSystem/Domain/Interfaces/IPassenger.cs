using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;


public interface IPassenger : IPerson
{
    List<ITicket> Tickets { get; }
    Baggage? Baggage { get; }
}