using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A1.Services
{
	public class UserService
	{
		private readonly AppDbContext _context;

		public UserService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Staff?> GetStaffByUserAsync(User user) => await _context.Staff.FirstOrDefaultAsync(s => s.Id == user.StaffId);

		public async Task<Patient?> GetPatientByUserAsync(User user) => await _context.Patients.FirstOrDefaultAsync(p => p.Id == user.PatientId);
	}
}
