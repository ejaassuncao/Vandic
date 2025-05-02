namespace Vandic.Application.Abstracts
{
    public class ResponseDto<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        public ResponseDto()
        {            
        }

        public ResponseDto(IEnumerable<T> result, int count)
        {
            TotalItems = count;
            Items = result;
        }
    }
}
