namespace Csharp3_A1.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public string DoctorName { get; set; } = string.Empty;
		public string Issue { get; set; } = string.Empty;
		public DateTime DateOfAppointment { get; set; }
	}
}
