namespace Assets.Code.Core
{
    public interface IKillable : IAspect
    {
        double HP { get; }
        void Damage(double value);
    }
}
