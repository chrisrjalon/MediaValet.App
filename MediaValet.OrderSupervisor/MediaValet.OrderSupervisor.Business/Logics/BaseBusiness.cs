using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediaValet.OrderSupervisor.DataAccess.Repositories;

namespace MediaValet.OrderSupervisor.Business.Logics
{
    public abstract class BaseBusiness
    {
        protected readonly IStorageFacade _storages;
        protected readonly IMapper _mapper;

        protected BaseBusiness(IStorageFacade storages, IMapper mapper)
        {
            _storages = storages;
            _mapper = mapper;
        }
    }
}
