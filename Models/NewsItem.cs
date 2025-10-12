namespace Csharp3_A1.Models
{
	public class NewsItem
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public string? ImagePath { get; set; } = "";
		public string? Url { get; set; } = "";
	}
}
