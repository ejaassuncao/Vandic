using Vandic.CrossCutting.Resources.Configurations;

namespace Vandic.Application.Abstracts
{
    public class FilterDto
    {  
        public string Search { get; set; }
        public string OrderByName { get; set; }
        public EnumDirection OrderByDirection { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
