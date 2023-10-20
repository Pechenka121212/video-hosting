namespace video_hosting.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        
        public string FileName { get; set; } = null!;
        
        public string PathToFile { get; set; } = null!;

        public Category Category { get; set; } = null!;

        public string? Description { get; set; }

        public string PathToThumbnail { get; set; } = null!;
    }
}
