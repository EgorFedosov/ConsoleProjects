using AirportSystem.Domain.Enums;
using AirportSystem.Domain.Interfaces;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Domain.Entities.Persons;

public class Person(string name, int age, Gender gender, Money money)
    : IPerson
{
    public string Name { get; } = name;
    public int Age { get; } = age;
    public Gender Gender { get; } = gender;
    public Money Money { get; } = money;
}