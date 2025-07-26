
namespace Grains.Models
{
    [GenerateSerializer]
    public class ToDoState
    {
        [Id(0)]
        public string Title { get; set; }
    }

}
