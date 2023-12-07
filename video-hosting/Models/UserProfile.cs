namespace video_hosting.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string PathToAvatar { get; set; }

        public string Nickname { get; set; }

        public string Gender { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public int Comments { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}
