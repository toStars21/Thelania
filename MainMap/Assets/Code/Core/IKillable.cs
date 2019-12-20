namespace Thelania.Core
{
    public interface IKillable
    {
        double HP { get; }
        void Damage(double value);
    }
}
