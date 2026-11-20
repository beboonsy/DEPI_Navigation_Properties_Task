namespace HealthCareSystem.Models;
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    // Many-to-many through Appointment
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
