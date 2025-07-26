using Interfaces;
using Orleans;

namespace Grains;

public class ToDoGrain : Grain, IToDoGrain
{ 
    private String _title;

    public Task SetTitle(string title)
    {
        _title = title;
        return Task.CompletedTask;
    }

    public Task<string> GetTitle()
    {
        return Task.FromResult(_title);
    }
}