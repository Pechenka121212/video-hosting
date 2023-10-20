using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using video_hosting.Services;

namespace video_hosting.Pages
{
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 524288000)]
    public class UploadVideoModel : PageModel
    {
        private IWebHostEnvironment _environment;

        private string _additionalPathToThumbnail = "/media/thumbnails/";

        private string _additionalPathToVideo = "/media/videos/";

        [BindProperty]
        public IFormFile UploadThumbnail { get; set; } = null!;

        [BindProperty]
        public IFormFile UploadVideo { get; set; } = null!;

        public string[] elementNames = { "videoName", "videoCategory", "description" };

        public UploadVideoModel(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }

        public IActionResult OnGet()
        {
            //if (!Auth())
            //{
            //    return RedirectToPage("Login");
            //}
            return Page();
        }

        public void OnPost()
        {
            string? videoName = Request.Form[elementNames[0]];
            string? videoCategory = Request.Form[elementNames[1]];
            string? description = Request.Form[elementNames[2]];

            if (!string.IsNullOrEmpty(videoName) && !string.IsNullOrEmpty(videoCategory))
            {
                string pathToUploadThumbnail = this._environment.WebRootPath + _additionalPathToThumbnail;
                if (!Directory.Exists(pathToUploadThumbnail))
                {
                    Directory.CreateDirectory(pathToUploadThumbnail);
                }
                using (var fileStream = new FileStream(pathToUploadThumbnail + UploadThumbnail.FileName, FileMode.Create))
                {
                    UploadThumbnail.CopyTo(fileStream);
                }

                string pathToUploadVideo = this._environment.WebRootPath + _additionalPathToVideo;
                if (!Directory.Exists(pathToUploadVideo))
                {
                    Directory.CreateDirectory(pathToUploadVideo);
                }
                using (var fileStream = new FileStream(pathToUploadVideo + UploadVideo.FileName, FileMode.Create))
                {
                    UploadVideo.CopyTo(fileStream);
                }

                ApplicationContext databaseConnection = new ApplicationContext();
                VideoService.AddNewVideo(databaseConnection, videoName, UploadVideo.FileName, this._additionalPathToVideo, videoCategory,
                    description, this._additionalPathToThumbnail + UploadThumbnail.FileName);
            }
        }
    }
}
