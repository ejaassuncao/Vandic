using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.Abstracts
{
    public interface IBaseCommand<TResult>: IRequest<ResultCommand<TResult>>
    {      
    }   
}
