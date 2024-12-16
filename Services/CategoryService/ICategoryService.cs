namespace InternshipPlatform.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<InternshipCategory>?> GetAllCategories();

        Task<InternshipCategory?> GetSingleCategory(int id);

        Task<List<InternshipCategory>?> AddCategory(InternshipCategory category);

        Task<List<InternshipCategory>?> UpdateCategory(int id, InternshipCategory request);

        Task<List<InternshipCategory>?> DeleteCategory(int id);
    }
}
