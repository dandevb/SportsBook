using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsBook.Services.Services
{
    public class EventService: IServices
    {
        private readonly IGenericRepository<Event> _repo;
        private readonly IGenericRepository<Market> _marketRepo;
        private readonly IGenericRepository<Sport> _sportRepo;

        private readonly DTOAssembler _assembler;


        public EventService(IGenericRepository<Event> repo, IGenericRepository<Market> marketRepo, IGenericRepository<Sport> sportRepo, DTOAssembler assembler)
        {
            _repo = repo;
            _marketRepo = marketRepo;
            _sportRepo = sportRepo;
            _assembler = assembler;
        }

        public bool Create(EventDTO newEvent)
        {
            try
            {
                newEvent.Active = false; //Should be created with Active false until a new market is created for it
                var _event = _assembler.WriteEntity(newEvent);

                var _sport = _sportRepo.GetByID(newEvent.SportId);

                if (_sport == null)
                {
                    Console.WriteLine("Sport ID not found. Event cannot be created.");
                    throw new KeyNotFoundException("Sport ID not found");
                }

                _event.SportEventList = new List<SportEvent>()
                {
                    new SportEvent()
                    {
                        Sport = _sport,
                        Event = _event
                    }
                };

                _repo.Insert(_event);

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

        public bool Delete(int eventId)
        {
            try
            {
                Event _event = _repo.GetByID(eventId);

                //Delete all markets linked to the event first
                if (_event != null && _event.MarketList != null)
                {
                    //TODO: improve this with a delete range option
                    foreach (var market in _event.MarketList)
                    {
                        _marketRepo.Delete(market.Id);
                    }
                }

                _repo.Delete(_event);

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

        public bool Update(EventDTO dto)
        {
            try
            {
                Event _event = _assembler.WriteEntity(dto);
                _repo.Update(_event);

                //If the event is disabled then we check all the sports linked to it
                if (_event.Active == false)
                {
                    var _list = _event.SportEventList.Select(x => x.Sport).Distinct();

                    foreach (var sport in _list)
                    {
                        sport.CheckActive();
                    }
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
