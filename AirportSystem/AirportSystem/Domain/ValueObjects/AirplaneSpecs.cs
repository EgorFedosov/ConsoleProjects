namespace AirportSystem.Domain.ValueObjects;

/// <summary>
/// Технические характеристики самолета.
/// </summary>
public sealed class AirplaneSpecs(string manufacturer, int modelYear, string engineType) : IEquatable<AirplaneSpecs>
{
    public string Manufacturer { get; } = manufacturer;
    public int ModelYear { get; } = modelYear;
    public string EngineType { get; } = engineType;

    public bool Equals(AirplaneSpecs? other)
    {
        if (other is null) return false;
        return Manufacturer == other.Manufacturer && ModelYear == other.ModelYear && EngineType == other.EngineType;
    }

    public override bool Equals(object? obj) => obj is AirplaneSpecs other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Manufacturer, ModelYear, EngineType);
}