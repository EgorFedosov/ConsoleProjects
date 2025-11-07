using AirportSystem.Domain.Aggregates;
using AirportSystem.Domain.Enums;
using AirportSystem.Domain.Interfaces;
using AirportSystem.Domain.Repositories;
using AirportSystem.Domain.ValueObjects;

namespace AirportSystem.Infrastructure.Repositories;

public class InMemoryAirportCompanyRepository : IAirportCompanyRepository
{
    private readonly IAirportCompany _company;
    public InMemoryAirportCompanyRepository()
    {
        _company = new AirportCompany(new Money(1000000, Currency.Usd));
    }

    public IAirportCompany Get() {
        return _company;
    }

}