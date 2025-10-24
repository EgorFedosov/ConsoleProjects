using AirportSystem.Domain.Enums;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IAirplane
{
    List<IPassenger> Passengers { get; }
    List<IPerson> Crew { get; }
    string Model { get; }
    int Capacity { get; }
    Money Price { get; }
    AirplaneStatus Status { get; set; }
}