
namespace Ballgame
{
    public interface ISaveData<T> where T : IData, new()
    {
        public string SavePath { get; set; }

        void Save(T _player);

        T Load();
    }
}
