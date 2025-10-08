using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.AspNetCore.Authentication;
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
			var user = await _context.Users.FindAsync(username);

			//Return null if user can not be found or password is wrong
			if (user == null) return null;

			if (user.Password != password) return null;

			//Return user if found and password is correct
			return user;
		}
	}
}
