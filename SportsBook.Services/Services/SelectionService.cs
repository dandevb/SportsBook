using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.DTO;
using System;
using System.Collections.Generic;

namespace SportsBook.Services.Services
{
    public class SelectionService: BaseService
    {
        #region Properties & constructors
        private readonly IGenericRepository<Selection> _repoSelection;
        private readonly IGenericRepository<Event> _repoEvent;
        private readonly IGenericRepository<Market> _repoMarket;

        public SelectionService(IUnitOfWork uow, DTOAssembler assembler) : base(uow, assembler)
        {
            _repoSelection = _uow.GetRepository<Selection>(); ;
            _repoEvent = _uow.GetRepository<Event>(); ;
            _repoMarket = _uow.GetRepository<Market>(); ;
        }
        #endregion

        public bool Create(SelectionDTO selec)
        {
            try
            {
                Selection newSelection = _assembler.WriteEntity(selec);

                //Validate linked entities
                var _market = _repoMarket.GetByID(selec.MarketId);
                var _event = _repoEvent.GetByID(selec.EventId);

                if (_market == null )
                {
                    //TODO: replace for proper error handling
                    Console.WriteLine("Market ID not found. Selection cannot be created.");
                    throw new KeyNotFoundException("Market ID not found");
                }
                if (_event == null)
                {
                    //TODO: replace for proper error handling
                    Console.WriteLine("Event ID not found. Selection cannot be created.");
                    throw new KeyNotFoundException("Event ID not found");
                }

                _repoSelection.Add(newSelection);
                _uow.Commit();

                return true;
            }
            catch (System.Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                _uow.Dispose();
                throw ex;
            }

            return false;
        }

        public bool Delete(int SelectionId)
        {
            try
            {
                Selection selec = _repoSelection.GetByID(SelectionId);

                Market _marketId = selec.Market;

                _repoSelection.Delete(selec);

                _marketId.CheckActive(); //If no selections exist or at least one is active, then market is disabled
                _uow.Commit();

                return true;
            }
            catch (System.Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                _uow.Dispose();
                throw ex;
            }

            return false;
        }

        public bool Update(SelectionDTO dto)
        {
            try
            {
                Selection selection = _assembler.WriteEntity(dto);
                _repoSelection.Update(selection);

                if (!selection.Active)
                {
                    selection.Market.CheckActive();
                }
                _uow.Commit();

                return true;
            }
            catch (System.Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                _uow.Dispose();
                throw ex;
            }

            return false;
        }
    }
}
