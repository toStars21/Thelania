namespace Assets.Code.Core
{
    public interface ICanUpgrade
    {
        int Level { get; }
        void Upgrade();
    }
}
