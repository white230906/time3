namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.CreateCategoryRequest request);
    public Task<List<Response.CreateCategoryResponse>> GetAllChildren();
}