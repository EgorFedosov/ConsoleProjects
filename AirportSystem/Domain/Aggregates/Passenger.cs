using AirportSystem.Domain.Entities;
using AirportSystem.Domain.Entities.Persons;
using AirportSystem.Domain.Enums;
using AirportSystem.Domain.Interfaces;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Aggregates;

public class Passenger(string name, int age, Gender gender, Money money, List<ITicket>? tickets, Baggage? baggage)
    : Person(name, age, gender, money), IPassenger
{
    public List<ITicket> Tickets { get; } = tickets ?? [];
    public Baggage? Baggage { get; private set; } = baggage;

    public bool AddTicket(ITicket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);
        if (Pay(ticket.Money) && baggage != null && ticket.IsBaggageAllowed(baggage))
        {
            Console.WriteLine("Ticket has been paid");
            ticket.Status = TicketStatus.Paid;
            Tickets.Add(ticket);
            return true;
        }

        Console.WriteLine("An error occured during payment");
        return false;
    }

    public void AssignBaggage(Baggage baggage)
    {
        ArgumentNullException.ThrowIfNull(baggage);
        Baggage = baggage;
    }
}