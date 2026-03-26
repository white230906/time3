namespace TetPee.Service.Category;

public class Request
{
    public class CreateCategoryRequest
    {
        public required string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}