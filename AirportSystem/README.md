### Обзор Проекта "AirportSystem"

Проект представляет собой симуляцию системы управления аэропортом, разработанную на C# .NET. Архитектура системы построена с использованием принципов Domain-Driven Design (DDD), SOLID и GRASP.

---

### Принципы Проектирования (DDD, SOLID, GRASP)

**Domain-Driven Design (DDD)**

- **Разделение слоев:** Проект четко разделен на слои: `Application` (Сервисы), `Domain` (Сущности, Агрегаты, Value Objects, Интерфейсы репозиториев) и `Infrastructure` (Реализации репозиториев).
- **Агрегаты (Aggregates):** Выделены ключевые агрегаты, такие как `Flight` (Рейс), `Passenger` (Пассажир) и `AirportCompany` (Авиакомпания). Агрегат `Flight` контролирует добавление пассажиров, проверяя вместимость самолета.
- **Value Objects (VOs):** Активно используются VO, такие как `Money` (для инкапсуляции суммы и валюты), `Route` (Маршрут), `Address` и `AirplaneSpecs` (Спецификации самолета). Они обеспечивают неизменяемость и валидацию.
- **Сущности (Entities):** Определены сущности, имеющие идентификатор (Id), такие как `Airplane`, `Person`, `Pilot`, `Ticket`.
- **Репозитории (Repositories):** Слой `Domain` определяет интерфейсы репозиториев (`IFlightRepository`, `IAirplaneRepository`), а `Infrastructure` предоставляет их "in-memory" реализации.
- **Сервисы Приложения (Application Services):** Классы, такие как `BookingService` и `FlightOperationsService`, координируют выполнение бизнес-операций, работая с агрегатами и репозиториями.

**SOLID**

- **S (Single Responsibility Principle):** Принцип соблюдается. `FinancialService` отвечает только за финансовые транзакции (оплата, возврат). `HumanResourcesService` отвечает за найм персонала. `FlightOperationsService` — за операции вылета и прилета.
- **O (Open/Closed Principle):** Использование интерфейсов (например, `IAirplane`, `IFlightRepository`) позволяет расширять систему (например, добавлять новые типы репозиториев), не изменяя существующий код сервисов.
- **I (Interface Segregation Principle):** Интерфейсы сфокусированы. `IPassenger`, `IPilot`, `IMaintenanceTechnician` наследуются от `IPerson`, но предоставляют только те методы и свойства, которые относятся к их роли.
- **D (Dependency Inversion Principle):** Принцип является основой архитектуры. Сервисы (`BookingService`, `FleetManagementService`) зависят от абстракций (`IFlightRepository`, `IFinancialService`), а не от конкретных реализаций (`InMemoryFlightRepository`). Зависимости внедряются через конструктор (Dependency Injection).

**GRASP**

- **Information Expert:** Ответственность возлагается на классы, владеющие информацией. `Passenger` (Пассажир) сам управляет своим `Money` (метод `Pay`). `Flight` (Рейс) сам решает, можно ли добавить пассажира (проверяя `Airplane.Capacity`). `Money` (Деньги) выполняет операции сложения и вычитания, зная о валюте.
- **Creator:** Создание объектов делегировано классам, которые имеют для этого всю необходимую информацию. `HumanResourcesService` создает (`Hire...`) `Pilot` и `MaintenanceTechnician`. `FleetManagementService` создает `Airplane`.
- **Controller / Facade:** Сервисы приложения (`BookingService`, `FlightOperationsService`) выступают в роли контроллеров, принимая запросы (например, "купить билет") и координируя работу объектов доменной модели.
- **Low Coupling (Низкая связанность):** Достигается за счет Dependency Inversion. `BookingService` не "знает" о `InMemoryFlightRepository`, он связан только с интерфейсом `IFlightRepository`.
- **High Cohesion (Высокая связность):** Классы имеют четко определенные и сфокусированные обязанности (см. SRP).

---

### Структура и Метрики Проекта

В подсчет включены все классы, интерфейсы, перечисления (enum) и исключения, определенные в проекте.

**Интерфейсы Приложения (Application Interfaces)**

- `IAirplaneMaintenanceService` 0 1 → MaintenanceRecord, IAirplane, IMaintenanceTechnician, Money
- `IBookingService` 0 2
- `IFinancialService` 0 2 → IPassenger, Money
- `IFleetManagementService` 0 3 → IAirplane, Money, AirplaneSpecs
- `IFlightManagementService` 0 2 → IFlight, IAirplane, IPilot, Route, Money
- `IFlightOperationsService` 0 2
- `IHumanResourcesService` 0 3 → IFlightAttendant, Gender, Money, IMaintenanceTechnician, MaintenanceCertification, IPilot

**Сервисы Приложения (Application Services)**

- `AirplaneMaintenanceService` 0 2 → IAirplaneMaintenanceService, IAirplane, IMaintenanceTechnician, Money, MaintenanceRecord
- `BookingService` 3 4 → IBookingService, IFlightRepository, IPassengerRepository, IFinancialService, IFlight, IPassenger, Ticket, TicketStatus
- `FinancialService` 1 4 → IFinancialService, IAirportCompanyRepository, IPassenger, Money, IAirportCompany
- `FleetManagementService` 1 5 → IFleetManagementService, IAirplaneRepository, IAirplane, AirplaneStatus, Money, AirplaneSpecs, Airplane
- `FlightManagementService` 1 4 → IFlightManagementService, IFlightRepository, IFlight, IAirplane, IPilot, Route, Money, Flight
- `FlightOperationsService` 1 4 → IFlightOperationsService, IFlightRepository, IFlight, FlightStatus, IAirplane, AirplaneStatus, TicketStatus
- `HumanResourcesService` 3 5 → IHumanResourcesService, IFlightAttendantRepository, IMaintenanceTechnicianRepository, IPilotRepository, IFlightAttendant, Gender, Money, FlightAttendant, IMaintenanceTechnician, MaintenanceCertification, MaintenanceTechnician, IPilot, Pilot

**Агрегаты (Domain Aggregates)**

- `AirportCompany` 4 4 → IAirportCompany, Money, Address
- `Flight` 11 5 → IFlight, IAirplane, IPilot, Route, Money, IPassenger, FlightStatus
- `Passenger` 3 6 → IPassenger, Person, Gender, Money, ITicket, Baggage, TicketStatus, Currency

**Сущности (Domain Entities)**

- `Baggage` 2 4
- `Ticket` 7 3 → ITicket, IPassenger, IFlight, TicketStatus, Money, IAirplane, Baggage
- `Airplane` 8 4 → IAirplane, Money, AirplaneStatus, MaintenanceRecord, AirplaneSpecs
- `FlightAttendant` 4 2 → Person, IFlightAttendant, Gender, Money, StaffDepartment
- `MaintenanceTechnician` 4 2 → Person, IMaintenanceTechnician, Gender, Money, MaintenanceCertification, StaffDepartment
- `Person` 8 2 → IPerson, Gender, Money, Address, ContactDetails, Passport, Currency
- `Pilot` 4 3 → Person, IPilot, Gender, Money, StaffDepartment

**Перечисления (Domain Enums)**

- `AirplaneStatus` 3 0
- `Currency` 3 0
- `FlightStatus` 6 0
- `Gender` 3 0
- `MaintenanceCertification` 3 0
- `StaffDepartment` 4 0
- `TicketStatus` 3 0

**Исключения (Domain Exceptions)**

- `InvalidCountryNameException` 0 1
- `CurrencyMismatchException` 0 1 → Currency
- `NegativeMoneyAmountException` 0 1
- `NotEnoughMoneyException` 0 1
- `InvalidDistanceException` 0 1

**Интерфейсы Домена (Domain Interfaces)**

- `IAirplane` 8 2 → Money, AirplaneStatus, MaintenanceRecord, AirplaneSpecs
- `IAirportCompany` 4 2 → Money, Address
- `IFlight` 8 3 → IAirplane, IPilot, IPassenger, Route, Money, FlightStatus
- `IFlightAttendant` 4 0 → IPerson, StaffDepartment
- `IMaintenanceTechnician` 4 0 → IPerson, StaffDepartment, MaintenanceCertification
- `IPassenger` 2 4 → IPerson, ITicket, Baggage, Money
- `IPerson` 5 0 → Gender, Money
- `IPilot` 1 0 → IPerson
- `ITicket` 4 1 → IPassenger, IFlight, Baggage, TicketStatus, Money

**Интерфейсы Репозиториев (Domain Repositories)**

- `IAirplaneRepository` 0 3 → IAirplane
- `IAirportCompanyRepository` 0 1 → IAirportCompany
- `IFlightAttendantRepository` 0 2 → IFlightAttendant
- `IFlightRepository` 0 3 → IFlight
- `IMaintenanceTechnicianRepository` 0 2 → IMaintenanceTechnician
- `IPassengerRepository` 0 2 → IPassenger
- `IPilotRepository` 0 2 → IPilot

**Value Objects (Domain ValueObjects)**

- `Address` 4 4 → Country
- `AirplaneSpecs` 3 4
- `ContactDetails` 2 4
- `Country` 1 6
- `MaintenanceRecord` 4 1 → Money
- `Money` 2 10 → Currency, CurrencyMismatchException, NegativeMoneyAmountException, NotEnoughMoneyException
- `Passport` 3 5 → Country
- `Route` 2 6 → Country, InvalidDistanceException

**Репозитории (Infrastructure Repositories)**

- `InMemoryAirplaneRepository` 1 3 → IAirplaneRepository, IAirplane
- `InMemoryAirportCompanyRepository` 1 1 → IAirportCompanyRepository, IAirportCompany, AirportCompany, Money, Currency
- `InMemoryFlightAttendantRepository` 1 2 → IFlightAttendantRepository, IFlightAttendant
- `InMemoryFlightRepository` 1 3 → IFlightRepository, IFlight
- `InMemoryMaintenanceTechnicianRepository` 1 2 → IMaintenanceTechnicianRepository, IMaintenanceTechnician
- `InMemoryPassengerRepository` 1 2 → IPassengerRepository, IPassenger
- `InMemoryPilotRepository` 1 2 → IPilotRepository, IPilot

---

### Итоговые Метрики

- **Классы (включая интерфейсы, enums, exceptions):** 68
- **Поля (Fields/Properties, вкл. Enum Members):** 158
- **Поведения (Methods/Constructors):** 164
- **Ассоциации (Ссылки на другие классы/интерфейсы проекта):** 182
- **Исключения (Exceptions):** 5
