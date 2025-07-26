using Grains.Models;
using Interfaces;
using Orleans;
using Orleans.Runtime;

namespace Grains
{
    public class PersistedToDoGrain : Grain, IPersistedToDoGrain
    {
        private readonly IPersistentState<ToDoState> _state;

        public PersistedToDoGrain([PersistentState("todo", "todoStore")] IPersistentState<ToDoState> state)
        {
            _state = state;
        }
        public async Task SetTitle(string title)
        {
            _state.State.Title = title;
            await _state.WriteStateAsync();
            Console.WriteLine("PersistentToDoGrain: Activated");

        }
        public Task<string> GetTitle()
        {
            return Task.FromResult(_state.State.Title);
        }
        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            string key = this.GetPrimaryKeyString();
            Console.WriteLine($"Grain activated with key: {key}");
            return base.OnActivateAsync(cancellationToken);
        }

    }
}
