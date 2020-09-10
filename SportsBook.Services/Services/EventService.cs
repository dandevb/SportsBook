using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsBook.Services.Services
{
    public class EventService: BaseService
    {
        #region Properties & constructors
        private readonly IGenericRepository<Event> _repoEvent;
        private readonly IGenericRepository<Market> _repoMarket;
        private readonly IGenericRepository<Sport> _repoSport;

        public EventService(IUnitOfWork uow, DTOAssembler assembler) : base(uow, assembler)
        {
            _repoEvent = _uow.GetRepository<Event>(); ;
            _repoMarket = _uow.GetRepository<Market>(); ;
            _repoSport = _uow.GetRepository<Sport>(); ;
        }
        #endregion

        public bool Create(EventDTO newEvent)
        {
            try
            {
                newEvent.Active = false; //Should be created with Active false until a new market is created for it
                var _event = _assembler.WriteEntity(newEvent);

                var _sport = _repoSport.GetByID(newEvent.SportId);

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

                _repoEvent.Add(_event);
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

        public bool Delete(int eventId)
        {
            try
            {
                Event _event = _repoEvent.GetByID(eventId);

                //Delete all markets linked to the event first
                if (_event != null && _event.MarketList != null)
                {
                    //TODO: improve this with a delete range option
                    foreach (var market in _event.MarketList)
                    {
                        _repoMarket.Delete(market);
                    }
                }

                _repoEvent.Delete(_event);
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

        public bool Update(EventDTO dto)
        {
            try
            {
                Event _event = _assembler.WriteEntity(dto);
                _repoEvent.Update(_event);

                //If the event is disabled then we check all the sports linked to it
                if (_event.Active == false)
                {
                    var _list = _event.SportEventList.Select(x => x.Sport).Distinct();

                    foreach (var sport in _list)
                    {
                        sport.CheckActive();
                    }
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
