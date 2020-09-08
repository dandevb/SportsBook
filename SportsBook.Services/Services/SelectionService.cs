using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.DTO;
using System;
using System.Collections.Generic;

namespace SportsBook.Services.Services
{
    public class SelectionService: IServices
    {
        private readonly IGenericRepository<Selection> _repo;
        private readonly IGenericRepository<Event> _eventRepo;
        private readonly IGenericRepository<Market> _marketRepo;

        private readonly DTOAssembler _assembler;

        public SelectionService(IGenericRepository<Selection> repo, IGenericRepository<Event> eventRepo, IGenericRepository<Market> marketRepo, DTOAssembler assembler)
        {
            _repo = repo;
            _eventRepo = eventRepo;
            _marketRepo = marketRepo;
            _assembler = assembler;
        }

        public bool Create(SelectionDTO selec)
        {
            try
            {
                Selection newSelection = _assembler.WriteEntity(selec);

                //Validate linked entities
                var _market = _marketRepo.GetByID(selec.MarketId);
                var _event = _eventRepo.GetByID(selec.EventId);

                if (_market == null )
                {
                    Console.WriteLine("Market ID not found. Selection cannot be created.");
                    throw new KeyNotFoundException("Market ID not found");
                }
                if (_event == null)
                {
                    Console.WriteLine("Event ID not found. Selection cannot be created.");
                    throw new KeyNotFoundException("Event ID not found");
                }

                _repo.Insert(newSelection);

                return true;
            }
            catch (System.Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return false;
        }

        public bool Delete(int SelectionId)
        {
            try
            {
                Selection selec = _repo.GetByID(SelectionId);

                Market _marketId = selec.Market;

                _repo.Delete(selec);

                _marketId.CheckActive(); //If no selections exist or at least one is active, then market is disabled

                return true;
            }
            catch (System.Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return false;
        }

        public bool Update(SelectionDTO dto)
        {
            try
            {
                Selection selection = _assembler.WriteEntity(dto);
                _repo.Update(selection);

                if (!selection.Active)
                {
                    selection.Market.CheckActive();
                }

                return true;
            }
            catch (System.Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return false;
        }
    }
}
