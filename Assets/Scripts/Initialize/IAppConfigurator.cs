using Cysharp.Threading.Tasks;

namespace Initialize
{
    public interface IAppConfigurator
    {
        UniTask Configure();
    }
}