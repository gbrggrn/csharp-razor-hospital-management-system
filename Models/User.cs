namespace Csharp3_A1.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;

		//If user is patient
		public int? PatientId { get; set; }
		public Patient? Patient { get; set; }

		//If user is staff
		public int? StaffId { get; set; }
		public Staff? Staff { get; set; }
	}
}
