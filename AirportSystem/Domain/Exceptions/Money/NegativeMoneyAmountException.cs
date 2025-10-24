namespace AirportSystem.Domain.Exceptions.Money;

/// <summary>Персональное исключение: отрицательная сумма.</summary>
public class NegativeMoneyAmountException(decimal amount) :
    Exception($"Сумма не может быть отрицательной: {amount}");