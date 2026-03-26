using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.User;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<string> CreateUser(Request.LoginRequest request)
    {
        var isEmailQuery = _dbContext.Users.Where(u => u.Email == request.Email);
        var isEmailExist = await isEmailQuery.AnyAsync();
        if (isEmailExist)
        {
            throw new Exception("Email does exist");
        }
      
        var user = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "User"
        };
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        return Response.Massage.CreateSuccess;
    }
    
}