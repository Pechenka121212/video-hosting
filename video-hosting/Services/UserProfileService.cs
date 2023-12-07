using video_hosting.Models;

namespace video_hosting.Services
{
    public class UserProfileService
    {
        public static UserProfile GetProfile(ApplicationContext database, int id)
        {
            List<UserProfile> UserProfiles = database.UserProfiles.ToList();
            UserProfile userProfile = null;
            foreach (UserProfile profile in UserProfiles)
            {
                if (profile.Id == id) userProfile = profile;
                break;
            }
            return userProfile;
        }
    }
}
