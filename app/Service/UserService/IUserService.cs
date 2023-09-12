namespace app.Service.UserService;

public interface IUserService
{
    public Task<List<User>> GetAll();

    public Task<User> GetById(Guid guid);

    public Task<User> AddSingle(User user);

    public Task<User> UpdateSingle(Guid guid, User currentUser);

    public Task<List<User>> DeleteById(Guid guid);

}