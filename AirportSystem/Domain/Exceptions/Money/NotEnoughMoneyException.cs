namespace AirportSystem.Domain.Exceptions.Money;

/// <summary>Персональное исключение: недостаточно средств.</summary>
public class NotEnoughMoneyException(decimal balance, decimal requested)
    : Exception($"Недостаточно средств. Баланс: {balance}, требуется: {requested}");