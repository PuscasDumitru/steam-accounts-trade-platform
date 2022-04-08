namespace Services.Interfaces
{
    public interface IServiceManager
    {
        IAnnouncementService AnnouncementService { get; }
        IAccountService AccountService { get; }
        IRoleService RoleService { get; }
        IUserService UserService { get; }
    }
}
