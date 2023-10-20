using video_hosting.Models;

namespace video_hosting.Services
{
    public class VideoService
    {
        public static List<Video> GetAllVideos(ApplicationContext database)
        {
            return database.Videos.ToList();
        }

        public static void AddNewVideo(ApplicationContext database, string videoName, string fileName, string pathToFile, string categoryName, string? description, string pathToThumbnail)
        {
            List<Category> allCategories = CategoryService.GetAllCategories(database);
            Video newVideo = new Video() { Name=videoName, FileName=fileName, PathToFile=pathToFile, Category=CategoryService.GetCategoryByName(database, categoryName), Description=description, PathToThumbnail=pathToThumbnail};
            database.Videos.Add(newVideo);
            database.SaveChanges();
        }
    }
}
