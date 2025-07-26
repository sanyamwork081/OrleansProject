namespace Interfaces
{
	public interface IToDoGrain : Orleans.IGrainWithStringKey
	{
		Task SetTitle(string title);

		Task<string> GetTitle();
	}
}