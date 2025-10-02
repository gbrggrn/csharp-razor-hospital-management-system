using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A1.Services
{
	public class NewsService
	{
		private readonly AppDbContext _context;

		public NewsService(AppDbContext context)
		{
			_context = context;
		}

		//Logic

		public async Task<List<NewsItem>> GetAllAsync() => await _context.NewsItems.ToListAsync();

		public async Task<NewsItem?> GetByIdAsync(int id) => await _context.NewsItems.FindAsync(id);
		
		public async Task AddAsync(NewsItem item)
		{
			_context.NewsItems.Add(item);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(NewsItem item)
		{
			_context.NewsItems.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(NewsItem item)
		{
			_context.NewsItems.Remove(item);
			await _context.SaveChangesAsync();
		}
	}
}
