using Orleans;

namespace Interfaces
{
    public interface IReminderGrain : IGrainWithStringKey
    {
        Task StartReminder(string reminderName, TimeSpan dueTime, TimeSpan period);
        Task StopReminder(string reminderName);
    }
}
