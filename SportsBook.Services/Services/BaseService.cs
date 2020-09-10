using SportsBook.Domain.SeedWork;
using SportsBook.Infrastructure.Repository;
using System;

namespace SportsBook.Services.Services
{
    public abstract class BaseService : IServices
    {
        protected readonly IUnitOfWork _uow;
        protected readonly DTOAssembler _assembler;

        public BaseService(IUnitOfWork uow, DTOAssembler assembler)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _assembler = assembler;
        }
    }
}
