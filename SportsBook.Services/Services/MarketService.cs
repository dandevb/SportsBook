using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBook.Services.Services
{
    public class MarketService: BaseService
    {
        #region Properties & constructors
        private readonly IGenericRepository<Market> _repoMarket;
        private readonly IGenericRepository<Event> _repoEvent;
        private readonly IGenericRepository<Selection> _repoSelection;

        public MarketService(IUnitOfWork uow, DTOAssembler assembler): base(uow, assembler)
        {
            _repoMarket = _uow.GetRepository<Market>();
            _repoEvent = _uow.GetRepository<Event>();
            _repoSelection = _uow.GetRepository<Selection>();
        }
        #endregion

        public bool Create(MarketDTO market)
        {
            try
            {
                market.Active = false; //Should be created with Active false until a new selection is created for it
                Market newMarket = _assembler.WriteEntity(market);

                var _event = _repoEvent.GetByID(market.EventForeignKey);

                if (_event == null)
                {
                    Console.WriteLine("Event ID not found. Market cannot be created.");
                    throw new KeyNotFoundException("Event ID not found");
                }

                _repoMarket.Add(newMarket);
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

        public bool Delete(int MarketId)
        {
            try
            {
                Market _market = _repoMarket.GetByID(MarketId);

                //Delete all selections linked to the market first
                if (_market != null && _market.SelectionList != null)
                {
                    //TODO: improve this with a delete range option
                    foreach (var selec in _market.SelectionList)
                    {
                        _repoSelection.Delete(selec);
                    }
                }

                _repoMarket.Delete(_market);
                _uow.Commit();

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Implement proper error handling
                Console.WriteLine(ex.Message);
                _uow.Dispose();
                throw ex;
            }

            return false;
        }

        public bool Update(MarketDTO dto)
        {
            try
            {
                Market market = _assembler.WriteEntity(dto);
                _repoMarket.Update(market);

                //If market is disabled then we check the father event for possible disable
                if (market.Active == false)
                {
                    market.Event.CheckActive();
                }
                _uow.Commit();

                return true;
            }
            catch (Exception ex)
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
