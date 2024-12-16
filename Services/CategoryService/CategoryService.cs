using InternshipPlatform.Data;

namespace InternshipPlatform.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private static List<InternshipCategory> Categories = new List<InternshipCategory>
            {
                new InternshipCategory
                {

                }
            };
        private readonly DataContext _context;
        public CategoryService(DataContext context)
        {
            _context = context;

        }

        public async Task<List<InternshipCategory>?> AddCategory(InternshipCategory category)
        {
            try
            {
                _context.InternshipCategories.Add(category);
                await _context.SaveChangesAsync();
                return await _context.InternshipCategories.ToListAsync();
            }
            catch (DbUpdateException ex) { 
                throw new Exception("Failed to add category to the database.", ex);
            }
        }

        public async Task<List<InternshipCategory>?> DeleteCategory(int id)
        {
            var category = await _context.InternshipCategories.FindAsync(id);
            if (category is null)
            {
                return null;
            }

            _context.InternshipCategories.Remove(category);
            await _context.SaveChangesAsync();

            return await _context.InternshipCategories.ToListAsync();

        }

        public async Task<List<InternshipCategory>?> GetAllCategories()
        {
            var categories = await _context.InternshipCategories.ToListAsync();
            return categories;
        }

        public async Task<InternshipCategory?> GetSingleCategory(int id)
        {
            var category = await _context.InternshipCategories.FindAsync(id);
            if (category is null)
            {
                return null;
            }
            return category;
        }

        public async Task<List<InternshipCategory>?> UpdateCategory(int id, InternshipCategory request)
        {
            var category = await _context.InternshipCategories.FindAsync(id);
            if (category is null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(request.CategoryName))
            {
                category.CategoryName = request.CategoryName;
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                category.Description = request.Description;
            }
            await _context.SaveChangesAsync();

            return await _context.InternshipCategories.ToListAsync();

        }
    }
}
