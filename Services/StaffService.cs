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
	}
}
