using AirportSystem.Domain.Aggregates;
using AirportSystem.Domain.Interfaces;

namespace AirportSystem.Application.Interfaces;

public interface IBookingService
{
    void PrintAllFlights();
    bool BuyTicket(IPassenger passenger, ITicket ticket);
}