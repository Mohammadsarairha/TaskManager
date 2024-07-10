namespace Domain.Interfaces
{
    public interface IAuthBase<T> where T : class
    {
        string CreateJWTToken(T user);
    }
}
