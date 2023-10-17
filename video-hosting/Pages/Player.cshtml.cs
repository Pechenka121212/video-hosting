using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace video_hosting.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly ILogger<PlayerModel> _logger;

        public string? PathToVideoFile { get; set; }

        public string? PathToThumbnail { get; set; }

        public PlayerModel(ILogger<PlayerModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string pathToVideoFile, string pathToThumbnail)
        {
            this.PathToVideoFile = pathToVideoFile;
            this.PathToThumbnail = pathToThumbnail;
        }
    }
}