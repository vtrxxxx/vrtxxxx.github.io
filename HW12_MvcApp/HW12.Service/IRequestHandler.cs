using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }

    public interface IRequestHandler<TResponse>
    {
        Task<TResponse> Handle();
    }
}
