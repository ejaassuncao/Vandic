using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.Abstracts
{
    public class BaseCommand<TResponse> : IRequest<ResultCommand<TResponse>> where TResponse : new()
    {      
    }   
}
