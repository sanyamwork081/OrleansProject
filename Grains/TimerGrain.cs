using Interfaces;
using Orleans.Timers;

namespace Grains
{
    public class TimerGrain : Grain, ITimerGrain
    {
        private IDisposable? _timer;

        private readonly ITimerRegistry _timerRegistry;
        private readonly IGrainContext _grainContext;

        public TimerGrain(IGrainContext grainContext, ITimerRegistry timerRegistry)
        {
            _grainContext = grainContext;
            _timerRegistry = timerRegistry;
        }

        public Task StartTimer(TimeSpan interval)
        {
            _timer?.Dispose();
            _timer = _timerRegistry.RegisterGrainTimer<object>(
                _grainContext,
                async (state,ct) =>
                {
                    Console.WriteLine($"Timer triggered at: {DateTime.UtcNow}");
                    await Task.CompletedTask;
                },
                null,
                new GrainTimerCreationOptions
                {
                    DueTime = TimeSpan.Zero,
                    Period = interval
                }
            );
            return Task.CompletedTask;
        }

        public Task StopTimer()
        {
            _timer?.Dispose();
            _timer = null;
            return Task.CompletedTask;
        }
    }
}
