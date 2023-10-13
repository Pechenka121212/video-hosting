using video_hosting.Models;

namespace video_hosting.Services
{
    public class VideoService
    {
        public static List<Video> GetAllVideos(ApplicationContext database)
        {
            return database.Videos.ToList();
        }
    }
}
