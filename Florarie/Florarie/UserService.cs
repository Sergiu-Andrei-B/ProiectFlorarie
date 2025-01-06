namespace Florarie;

public class UserService
{
    private UserRepo repo;

    public UserService(UserRepo repo)
    {
        this.repo = repo;
    }

    public bool add(Utilizator utilizator)
    {
        return repo.add(utilizator);
    }

    public Utilizator findOne(string code)
    {
        return repo.findOne(code);
    }
}