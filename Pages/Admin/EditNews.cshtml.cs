using Csharp3_A1.Models;
using Csharp3_A1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Csharp3_A1.Pages.Admin
{
    public class EditNewsModel : PageModel
    {
        private readonly NewsService _newsService;
        public NewsItem NewsItem { get; set; } = new NewsItem();

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

            NewsItem= newsItem;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _newsService.UpdateAsync(NewsItem);
            return RedirectToPage("/Admin/NewsManagement");
        }
    }
}
