namespace AirportSystem.Domain.ValueObjects;

/// <summary>
/// Запись об обслуживании.
/// </summary>
public sealed class MaintenanceRecord
{
    public Guid MaintenanceId { get; }
    public DateTime DatePerformed { get; }
    public string Description { get; }
    public Money Cost { get; }
    public Guid TechnicianId { get; } 

    public MaintenanceRecord(DateTime datePerformed, string description, Money cost, Guid technicianId)
    {
        MaintenanceId = Guid.NewGuid();
        DatePerformed = datePerformed;
        Description = description;
        Cost = cost;
        TechnicianId = technicianId;
    }
}