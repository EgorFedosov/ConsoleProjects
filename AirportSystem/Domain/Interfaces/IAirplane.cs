using AirportSystem.Domain.Enums;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IAirplane
{
    List<IPassenger> Passengers { get; }
    List<IPilot> Crew { get; }
    string Model { get; }
    uint Capacity { get; }
    uint MaxWeightBaggage { get; }
    Money Price { get; }
    AirplaneStatus? Status { get; set; }
    void Print();
}