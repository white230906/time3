using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> CreateCategory(Request.CreateCategoryRequest request)
    {
        var existSlectedQuery = _dbContext.Categories.Where(x => x.Name == request.Name);
        var isExistCategory = await existSlectedQuery.AnyAsync();
        if (isExistCategory)
        {
            throw new Exception("Category already exists");
        }

        var category = new Repository.Entity.Category()
        {
            Name = request.Name,
            ParentId = request.ParentId
        };
        _dbContext.Add(category);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Category created";
        }
        return "Category could not be created";
    }

    public async Task<List<Response.CreateCategoryResponse>> GetAllChildren()
    {
        var query = _dbContext.Categories.Where(x => true );
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query.Select(x => new Response.CreateCategoryResponse()
        {
            Name = x.Name,
            ParentId = x.ParentId
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }
}