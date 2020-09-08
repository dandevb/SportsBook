using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBook.Services.Services
{
    public class MarketService: IServices
    {
        private readonly IGenericRepository<Market> _repo;
        private readonly IGenericRepository<Event> _eventRepo;
        private readonly IGenericRepository<Selection> _selectionRepo;

        private readonly DTOAssembler _assembler;

        public MarketService(IGenericRepository<Market> repo, IGenericRepository<Event> eventRepo, IGenericRepository<Selection> selectionRepo, DTOAssembler assembler)
        {
            _repo = repo;
            _eventRepo = eventRepo;
            _selectionRepo = selectionRepo;
            _assembler = assembler;
        }

        public bool Create(MarketDTO market)
        {
            try
            {
                market.Active = false; //Should be created with Active false until a new selection is created for it
                Market newMarket = _assembler.WriteEntity(market);

                var _event = _eventRepo.GetByID(market.EventForeignKey);

                if (_event == null)
                {
                    Console.WriteLine("Event ID not found. Market cannot be created.");
                    throw new KeyNotFoundException("Event ID not found");
                }

                _repo.Insert(newMarket);

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

        public bool Delete(int MarketId)
        {
            try
            {
                Market _market = _repo.GetByID(MarketId);

                //Delete all selections linked to the market first
                if (_market != null && _market.SelectionList != null)
                {
                    //TODO: improve this with a delete range option
                    foreach (var selec in _market.SelectionList)
                    {
                        _selectionRepo.Delete(selec.Id);
                    }
                }

                _repo.Delete(_market);

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

        public bool Update(MarketDTO dto)
        {
            try
            {
                Market market = _assembler.WriteEntity(dto);
                _repo.Update(market);

                //If market is disabled then we check the father event for possible disable
                if (market.Active == false)
                {
                    market.Event.CheckActive();
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
