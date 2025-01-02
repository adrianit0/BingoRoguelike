using Database;

namespace Editor {
    public interface IModulo {

        void OnList(BingoDatabase database);
        void OnBody(BingoDatabase database);

        string GetName(BingoDatabase database, int i);
    }
}