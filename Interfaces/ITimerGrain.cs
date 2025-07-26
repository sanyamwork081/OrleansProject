using Orleans;

namespace Interfaces
{
    public interface ITimerGrain : IGrainWithStringKey
    {
        Task StartTimer(TimeSpan interval);
        Task StopTimer();
    }
}
