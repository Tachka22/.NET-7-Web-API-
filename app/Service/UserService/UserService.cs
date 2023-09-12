using Microsoft.EntityFrameworkCore;

namespace app.Service.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public async Task<User> AddSingle(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
      
    public async Task<List<User>> DeleteById(Guid guid)
    {
        await _context.Users.Where(x => x.Guid == guid).ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
        return await _context.Users.ToListAsync();
    }

    public async Task<List<User>> GetAll()
    {
        var result =  await _context.Users.ToListAsync();
        if (result is null) return null;
        return result;
    }

    public  async Task<User> GetById(Guid guid)
    {
        var result =  await _context.Users.FindAsync(guid);
        if (result is null) return null;
        return result;
    }

    public  async Task<User> UpdateSingle(Guid guid, User currentUser)
    {
        //result.Login = currentUser.Login;
        //result.Password = currentUser.Password;
        //result.Name = currentUser.Name;
        //result.Admin = currentUser.Admin;
        //result.BirthDay= currentUser.BirthDay;
        //result.Gender = currentUser.Gender;
        //result.CreatedOn = currentUser.CreatedOn;
        //result.CreatedBy = currentUser.CreatedBy;
        //result.ModifiedOn= currentUser.ModifiedOn;
        //result.ModifiedBy = currentUser.ModifiedBy;
        //result.RevokedOn= currentUser.RevokedOn;
        //result.RevokedBy = currentUser.RevokedBy;
        if (currentUser is null) return null;
        var result = await _context.Users.Where(x => x.Guid == guid)
        .ExecuteUpdateAsync(s => s
            .SetProperty(u => u.Login, u => currentUser.Login)
            .SetProperty(u => u.Password, u => currentUser.Password)
            .SetProperty(u => u.Name, u => currentUser.Name)
            .SetProperty(u => u.Admin, u => currentUser.Admin)
            .SetProperty(u => u.BirthDay, u => currentUser.BirthDay)
            .SetProperty(u => u.Gender, u => currentUser.Gender)
            .SetProperty(u => u.CreatedOn, u => currentUser.CreatedOn)
            .SetProperty(u => u.CreatedBy, u => currentUser.CreatedBy)
            .SetProperty(u => u.ModifiedOn, u => currentUser.ModifiedOn)
            .SetProperty(u => u.ModifiedBy, u => currentUser.ModifiedBy)
            .SetProperty(u => u.RevokedOn, u => currentUser.RevokedOn)
            .SetProperty(u => u.RevokedBy, u => currentUser.RevokedBy)
            );

        await _context.SaveChangesAsync();
        return currentUser;
    }
}