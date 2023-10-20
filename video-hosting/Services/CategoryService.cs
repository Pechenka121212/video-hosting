using video_hosting.Models;

namespace video_hosting.Services
{
    public class CategoryService
    {
        public static List<Category> GetAllCategories(ApplicationContext database)
        {
            return database.Categories.ToList();
        }

        public static Category GetCategoryByName(ApplicationContext database, string categoryName)
        {
            Category result = new Category();
            List<Category> allCategories = database.Categories.ToList();

            foreach(Category category in allCategories)
            {
                if (categoryName == category.Name)
                {
                    result = category;
                    break;
                }
            }

            return result;
        }
    }
}
