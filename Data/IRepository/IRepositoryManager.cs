namespace Data.IRepository
{
    public interface IRepositoryManager
    {
        IUsersRepository UsersRepository { get; }
        IRolesRepository RolesRepository { get; }
    }
}
