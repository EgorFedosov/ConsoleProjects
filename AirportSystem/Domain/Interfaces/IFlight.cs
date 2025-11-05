using AirportSystem.Domain.Entities;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IFlight
{
    IAirplane Airplane { get; }
    IReadOnlyCollection<IPilot> Crew { get; }
    IReadOnlyCollection<IPassenger> Passengers { get; }
    Route Route { get; }
    public uint MaxWeightBaggage => Airplane.MaxWeightBaggage;
    Money TicketPrice { get; }
    Guid FlightId { get; }

    void Print();
    
    void AddPassenger(IPassenger passenger);
    void UpdateTicketPrice(Money newPrice);
}