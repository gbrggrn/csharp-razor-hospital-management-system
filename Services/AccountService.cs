using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Csharp3_A1.Services
{
	public class AccountService
	{
		private readonly AppDbContext _context;

		public AccountService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<User?> AuthenticateAsync(string username, string password)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

			//Return null if user can not be found or password is wrong
			if (user == null || user.Password != password)
				return null;

			//Return user if found and password is correct
			return user;
		}

		public async Task<User?> GetByUserNameAsync(string username)
		{
			return await _context.Users.Include(u => u.Patient).Include(u => u.Staff).FirstOrDefaultAsync(u => u.Username == username);
		}
	}
}
