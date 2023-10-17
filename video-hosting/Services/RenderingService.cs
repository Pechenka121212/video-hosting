using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using video_hosting.Models;

namespace video_hosting.Services
{
    public class RenderingService
    {
        private static string RenderCard(string pathToVideoFile, string videoFileName, string videoName, string pathToImg) 
        {
            string result =
                $"<a class=\"d-block col-3 link-opacity-50-hover\" style=\"text-decoration: none\" href=\"/Player?pathToVideoFile={pathToVideoFile + videoFileName}&pathToThumbnail={pathToImg}\">" +
                    "<div class=\"bg-secondary\">" +
                        "<div class=\"ratio ratio-16x9\">" +
                            $"<img class= \"img-fluid mx-auto d-block\" src=\"{pathToImg}\">" +
                        "</div>" +
                        $"<p class=\"text-center text-white\">{videoName}</p>" +
                    "</div>" +
                "</a>";

            return result;
        }

        public static ContentResult RenderAllThumbnail(ApplicationContext database)
        {
            List<Video> videos = VideoService.GetAllVideos(database);
            string result = "";

            foreach (Video video in videos)
            {
                result += RenderCard(video.PathToFile, video.FileName, video.Name, video.PuthToThumbnail);
            }

            return new ContentResult
            {
                Content = result,
                ContentType = "text/html"
            };
        }
    }
}
