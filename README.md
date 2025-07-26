# Orleans Learning Project

This project is a hands-on implementation of core concepts in [Microsoft Orleans](https://learn.microsoft.com/en-us/dotnet/orleans/), a virtual actor framework for building distributed, scalable, and fault-tolerant applications.  
It demonstrates how to build and interact with grains, enable persistent state storage, and use built-in scheduling features like timers and reminders.

## 🧠 Features Implemented

### ✅ Grains
- **Basic Grains**: Stateless grains with business logic encapsulated in virtual actors.
- **Interfaces**: Defined via `IGrainWithStringKey` contracts for strong type safety and grain resolution.

### 💾 Persistence
- **Persistent Grains** using `IPersistentState<T>`.
- Stores grain state in a storage provider (e.g., in-memory or ADO.NET depending on configuration).
- Automatic state rehydration and save on method completion or manually via `WriteStateAsync()`.

### ⏱️ Timers
- Implemented **grain-specific timers** using `ITimerRegistry.RegisterGrainTimer<T>()`.
- Supports periodic callbacks while the grain is active.
- Timer cleanup is automatically handled on grain deactivation.

### ⏰ Reminders
- Implemented **persistent reminders** via `IRemindable` interface.
- Supports durable scheduling of tasks that survive grain deactivation/reboots.
- Uses `RegisterOrUpdateReminder()` and `ReceiveReminder()` for lifecycle handling.

## 🧪 Testing
- Each component is testable via a simple Orleans client (console app).
- The client demonstrates:
  - Creating and calling grains
  - Triggering and stopping timers
  - Registering and handling reminders
  - Inspecting persisted state

## 🛠 Tech Stack
- **.NET 8**
- **Orleans 8.2.0**
- Console app project (no ASP.NET host used)
- Orleans SDK-based silo and client setup (`UseOrleans`, `UseOrleansClient`)

## 🔧 Run Instructions

### 1. Start the Silo
```bash
dotnet run --project OrleansSilo
