using AirportSystem.Domain.Exceptions.Country;

namespace AirportSystem.Domain.ValueObjects;

/// <summary> Value Object, хранит название страны. /// </summary>
public sealed class Country : IEquatable<Country>
{
    /// <summary>Полное название (например, "Минск, Беларусь").</summary>
    public string Name { get; }

    public Country(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidCountryNameException(nameof(name));

        Name = name;
    }

    public bool Equals(Country? other)
        => other is not null && Name == other.Name;

    public override bool Equals(object? obj)
        => obj is Country country && Equals(country);

    public override int GetHashCode()
        => Name.GetHashCode();

    public static bool operator ==(Country? left, Country? right)
        => Equals(left, right);

    public static bool operator !=(Country? left, Country? right)
        => !Equals(left, right);
}