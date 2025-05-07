namespace Vandic.Application.Abstracts
{
    public class ResponseQueryDto<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        public ResponseQueryDto()
        {            
        }

        public ResponseQueryDto(IQueryable<T> query, FilterDto filter)
        {
            int count = query.Count();
            var result = query.Skip(filter.Page * filter.PageSize).Take(filter.PageSize).ToList();

            TotalItems = count;
            Items = result;
        }
    }
}
