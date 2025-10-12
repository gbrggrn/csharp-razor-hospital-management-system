using Csharp3_A1.Models;
using Csharp3_A1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Csharp3_A1.Pages.Admin
{
    public class EditNewsModel : PageModel
    {
        [BindProperty]
        public NewsItem NewsItem { get; set; } = new NewsItem();

		private readonly NewsService _newsService;

		public EditNewsModel(NewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var newsItem = await _newsService.GetByIdAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            NewsItem = newsItem;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var itemToUpdate = await _newsService.GetByIdAsync(NewsItem.Id);
            if (itemToUpdate == null)
                return NotFound();

            itemToUpdate.Title = NewsItem.Title;
            itemToUpdate.Content = NewsItem.Content;
            itemToUpdate.ImagePath = NewsItem.ImagePath;
            itemToUpdate.Url = NewsItem.Url;

            await _newsService.UpdateAsync(itemToUpdate);
            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
