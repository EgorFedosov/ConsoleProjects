using AirportSystem.Domain.Entities;

namespace AirportSystem.Domain.Interfaces;

public interface IPassenger : IPerson
{
    List<ITicket> Tickets { get; }
    Baggage? Baggage { get; }
    public bool AddTicket(ITicket ticket);
    public void AssignBaggage(Baggage baggage);
}