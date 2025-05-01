using MudBlazor;

namespace Vandic.MudBlazorServer.Components.Services.Abstraction
{
    public class FilterViewModel<T>
    {
        public string Search { get; set; }

        public GridState<T> State { get; set; } = new GridState<T>();

        public FilterViewModel(string search, GridState<T> state)
        {
            Search = search;
            State = state;
        }

    }
}
