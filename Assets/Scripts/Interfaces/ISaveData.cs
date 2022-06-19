
namespace Ballgame
{
    public interface ISaveData<T> where T : IData, new()
    {
        void Save(T _player);

        T Load();
    }
}
