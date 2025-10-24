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

    public void AddTicket(ITicket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);
        Tickets.Add(ticket);
    }

    public void AssignBaggage(Baggage baggage)
    {
        ArgumentNullException.ThrowIfNull(baggage);
        Baggage = baggage;
    }
}