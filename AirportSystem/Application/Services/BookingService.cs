using AirportSystem.Application.Interfaces;
using AirportSystem.Domain.Aggregates;
using AirportSystem.Domain.Interfaces;

namespace AirportSystem.Application.Services;

public class BookingService(AirportCompany company) : IBookingService
{
    public void PrintAllFlights()
        => company.PrintAllFlights();

    public bool BuyTicket(IPassenger passenger, ITicket ticket)
        => passenger.AddTicket(ticket);
}