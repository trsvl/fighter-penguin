public interface IHealth
{
    int Health { get; }
    public abstract void Damage(int health);
}
