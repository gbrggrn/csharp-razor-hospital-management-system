using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A1.Services
{
	public class StaffService
	{
		private readonly AppDbContext _context;

		public StaffService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Staff>> GetAllAsync() => await _context.Staff.ToListAsync();

		public async Task<Staff?> GetByIdAsync(int id) => await _context.Staff.FindAsync(id);

		public async Task<List<Appointment>> GetAllAppointmentsByIdAsync(int staffId) => await _context.Appointments.Where(a => a.StaffId == staffId).ToListAsync();

		public async Task<List<MedicalHistory>> GetRelevantMedicalHistoryByIdAsync(int staffId) => await _context.MedicalHistories.Where(m => m.StaffId == staffId).ToListAsync();
	}
}
