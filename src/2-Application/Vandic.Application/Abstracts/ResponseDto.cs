namespace Vandic.Application.Abstracts
{
    public class ResponseDto<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        public ResponseDto(IEnumerable<T> result)
        {
            TotalItems = result.Count();
            Items = result;
        }
    }
}
