using AirportSystem.Domain.Enums;
using AirportSystem.Domain.Interfaces;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Entities.Airplanes;

public class Airplane(
    string model,
    uint capacity,
    Money price,
    List<IPilot>? crew,
    List<IPassenger>? passengers,
    AirplaneStatus status = AirplaneStatus.Available)
    : IAirplane
{
    public List<IPassenger> Passengers { get; } = passengers ?? [];
    public List<IPilot> Crew { get; } = crew ?? [];
    public string Model { get; } = model;
    public uint Capacity { get; } = capacity;
    public Money Price { get; } = price;
    public AirplaneStatus? Status { get; set; } = status;
}