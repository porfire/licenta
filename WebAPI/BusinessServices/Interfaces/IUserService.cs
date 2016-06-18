namespace BusinessServices.Interfaces
{
    public interface IUserService
    {
        int Authenticate(string userName, string password);
    }
}
