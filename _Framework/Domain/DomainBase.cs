namespace _Framework.Domain;

public class DomainBase<TIdentity>
{
    public TIdentity Id { get; private set; }
    public DateTime CreationDate { get; private set; }

    public DomainBase()
    {
        CreationDate = DateTime.Now;
    }
}