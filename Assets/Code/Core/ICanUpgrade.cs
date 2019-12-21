namespace Assets.Code.Core
{
    public interface ICanUpgrade : IAspect
    {
        int Level { get; }
        void Upgrade();
    }
}
