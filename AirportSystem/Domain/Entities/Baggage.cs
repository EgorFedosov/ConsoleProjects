using AirportSystem.Domain.Interfaces;

namespace AirportSystem.Domain.Entities;

public class Baggage : IEquatable<Baggage>
{
    public double WeightKg { get;
    }
    private Guid BaggageId { get; } = Guid.NewGuid();
    public IPassenger Owner { get;
    } 


    private const double Tolerance = 0.0001;
    public Baggage(double weightKg, IPassenger owner)
    {
        if (weightKg <= 0)
            throw new ArgumentException("Вес багажа должен быть положительным.", nameof(weightKg));
        WeightKg = weightKg;
        Owner = owner ?? throw new ArgumentNullException(nameof(owner));
    }

    public bool Equals(Baggage? other)
    {
        if (other is null) return false;
        return BaggageId == other.BaggageId;
    }

    public override bool Equals(object? obj)
    {
        return obj is Baggage baggage && Equals(baggage);
    }

    public override int GetHashCode()
    {
        return BaggageId.GetHashCode();
    }
}