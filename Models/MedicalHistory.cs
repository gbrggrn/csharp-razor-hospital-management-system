namespace Csharp3_A1.Models
{
	public class MedicalHistory
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public required Patient Patient { get; set; }

		public DateTime DateOfVisit { get; set; }
		public string Reason { get; set; } = string.Empty;
		public string Notes { get; set; } = string.Empty;
	}
}
