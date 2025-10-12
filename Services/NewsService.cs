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

		public async Task<List<NewsItem>> GetAllAsync() => await _context.NewsItems.ToListAsync();

		public async Task<NewsItem?> GetByIdAsync(int id) => await _context.NewsItems.FindAsync(id);
		
		public async Task AddAsync(NewsItem item)
		{
			_context.NewsItems.Add(item);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(NewsItem item)
		{
			var itemToUpdate = await _context.NewsItems.FindAsync(item.Id);
			if (itemToUpdate == null)
				return;

			itemToUpdate.Title = item.Title;
			itemToUpdate.Content = item.Content;
			itemToUpdate.ImagePath = item.ImagePath;
			itemToUpdate.Url = item.Url;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var item = await _context.NewsItems.FindAsync(id);
			if (item != null)
			{
				_context.NewsItems.Remove(item);
				await _context.SaveChangesAsync();
			}
		}
	}
}
