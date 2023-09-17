using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Hotels.GetAll
{
    public class GetAllQuery
    {

        private readonly IUnitOfWork _unitOfWork;
        public GetAllQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response<List<GetAllResponse>> Handle()
        {
            
        }
    }
}
