using SuperheroAPI.Entites;

namespace SuperheroAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
