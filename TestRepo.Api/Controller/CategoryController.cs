using Microsoft.AspNetCore.Mvc;
using TetPee.Repository.Entity;
using TetPee.Service.Category;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IService _categoryService;

    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateCategory(Request.CreateCategoryRequest request)
    {
        var newCate = await _categoryService.CreateCategory(request);
        return Ok(newCate);
    }

    [HttpGet()]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllChildren();
        return Ok(categories);
    }
    [HttpGet("{parentId}")]
    public async Task<IActionResult> GetAllCategoriesByParentId(Guid parentId)
    {
        var categories = await _categoryService.GetAllChildrenByParentId(parentId);
        return Ok(categories);
    }
}