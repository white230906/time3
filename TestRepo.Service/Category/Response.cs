namespace TetPee.Service.Category;

public class Response
{
    public class CreateCategoryResponse
    {
        public required string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}