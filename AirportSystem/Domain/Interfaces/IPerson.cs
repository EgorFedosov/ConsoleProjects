using AirportSystem.Domain.Enums;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Interfaces;

public interface IPerson
{
    string Name { get; }
    int Age { get; }
    Gender Gender { get; }
    Money Money { get;  }
    bool Pay(Money money);
}   