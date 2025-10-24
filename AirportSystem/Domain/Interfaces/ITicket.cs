using AirportSystem.Domain.Enums;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface ITicket
{
    IPassenger Passenger { get; }
    IFlight Flight { get; }
    TicketStatus Status { get; set; }
    Money Price { get; }
}