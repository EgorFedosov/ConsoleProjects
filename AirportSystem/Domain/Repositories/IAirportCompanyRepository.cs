using AirportSystem.Domain.Aggregates;
using AirportSystem.Domain.Interfaces;

namespace AirportSystem.Domain.Repositories;

public interface IAirportCompanyRepository
{
    IAirportCompany Get(); 
}