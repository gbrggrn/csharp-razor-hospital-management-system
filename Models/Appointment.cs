namespace Csharp3_A1.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public string Reason { get; set; } = string.Empty;
		public DateTime DateOfAppointment { get; set; }

		public int PatientId { get; set; }
		public Patient? Patient { get; set; }

		public int StaffId { get; set; }
		public Staff? Staff { get; set; }
	}
}
