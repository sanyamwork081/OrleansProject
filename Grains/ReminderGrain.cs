using Interfaces;
using Orleans;

namespace Grains
{
    public class ReminderGrain : Grain, IReminderGrain, IRemindable
    {
        public Task ReceiveReminder(string reminderName, TickStatus status)
        {
            Console.WriteLine($"[REMINDER] '{reminderName}' triggered at: {DateTime.UtcNow}, Grain: {this.GetPrimaryKeyString()}");
            return Task.CompletedTask;
        }

        public async Task StartReminder(string reminderName, TimeSpan dueTime, TimeSpan period)
        {
            var existingReminder = await this.GetReminder(reminderName);
            if (existingReminder != null)
            {
                await this.RegisterOrUpdateReminder(reminderName, dueTime, period);
                Console.WriteLine($"Reminder '{reminderName}' updated with due time {dueTime} and period {period}.");
            }
            else
            {
                Console.WriteLine($"Reminder '{reminderName}' already exists.");
            }
        }

        public async Task StopReminder(string reminderName)
        {
            var reminder = await this.GetReminder(reminderName);
            if (reminder != null)
            {
                await this.UnregisterReminder(reminder);
                Console.WriteLine($"Reminder '{reminderName}' unregistered.");
            }            
        }
    }
}
