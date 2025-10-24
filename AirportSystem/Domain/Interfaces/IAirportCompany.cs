using System.Collections.ObjectModel;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IAirportCompany
{
    ReadOnlyCollection<IAirplane> Airplanes { get; }
    ReadOnlyCollection<IPilot> Staff { get; }
    ReadOnlyCollection<IFlight> Flights { get; }
    Money Balance { get; }

    void AddAirplane(IAirplane airplane);
    void AddPilot(IPilot pilot);
    void AddFlight(IFlight flight);
    void AddBalance(Money amount);
}