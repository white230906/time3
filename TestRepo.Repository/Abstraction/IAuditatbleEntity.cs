namespace TetPee.Repository.Abstraction;

public interface IAuditatbleEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}