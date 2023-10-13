namespace video_hosting.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string FileName { get; set; }
        
        public string PathToFile { get; set; }

        public string Categories { get; set; }

        public string Description { get; set; }

        public string PuthToThumbnail { get; set; }
    }
}
