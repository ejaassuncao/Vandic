using MudBlazor;

namespace Vandic.MudBlazorServer.Components.Resources
{
    public class MudLocalizationPtBr : MudLocalizer
    {
        public string TablePaginationOf => "de";
        public string TablePaginationItemsPerPage => "Itens por página:";
        public string TablePaginationAll => "Todos";
        public string TablePaginationNextPage => "Próxima página";
        public string TablePaginationPreviousPage => "Página anterior";
        public string TablePaginationFirstPage => "Primeira página";
        public string TablePaginationLastPage => "Última página";
        public string TablePaginationText(int firstIndex, int lastIndex, int totalItems)
            => $"{firstIndex}-{lastIndex} de {totalItems}";
                
    }
}
