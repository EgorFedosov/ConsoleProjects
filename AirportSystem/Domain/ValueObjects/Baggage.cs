namespace AirportSystem.Domain.ValueObjects
{
    /// <summary>
    /// Багаж пассажира.
    /// </summary>
    public class Baggage : IEquatable<Baggage>
    {
        /// <summary>Вес багажа в килограммах.</summary>
        public double WeightKg { get; }

        private const double Tolerance = 0.0001;


        public Baggage(double weightKg)
        {
            if (weightKg <= 0)
                throw new ArgumentException("Вес багажа должен быть положительным.", nameof(weightKg));

            WeightKg = weightKg;
        }

        public bool Equals(Baggage? other)
        {
            if (other is null) return false;
            return Math.Abs(WeightKg - other.WeightKg) < Tolerance;
        }

        public override bool Equals(object? obj)
        {
            return obj is Baggage baggage && Equals(baggage);
        }

        public override int GetHashCode()
        {
            return WeightKg.GetHashCode();
        }
    }
}