

namespace Interfaces
{
    public interface IPersistedToDoGrain : Orleans.IGrainWithStringKey
    {
        Task SetTitle(string title);
        Task<string> GetTitle();
    }
}
