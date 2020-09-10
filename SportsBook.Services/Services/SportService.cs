using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.DTO;
using System;

namespace SportsBook.Services.Services
{
    public class SportService : BaseService
    {
        #region Properties & constructors
        private readonly IGenericRepository<Sport> _repoSport;
        private readonly IGenericRepository<Event> _repoEvent;       

        public SportService(IUnitOfWork uow, DTOAssembler assembler): base(uow, assembler)
        {
            _repoSport = _uow.GetRepository<Sport>();
            _repoEvent = _uow.GetRepository<Event>();
        }
        #endregion

        public bool Create(SportDTO newSport)
        {
            try
            {
                newSport.Active = false; //Should always start false until a new active event is created
                _repoSport.Add(_assembler.WriteEntity(newSport));
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
        }

        public bool Delete(int sportId)
        {
            try
            {
                Sport _sport = _repoSport.GetByID(sportId);

                //Delete all events linked to the sport first
                if (_sport != null && _sport.SportEventList != null)
                {
                    //TODO: improve this with a delete range option
                    foreach (var se in _sport.SportEventList)
                    {
                        _repoEvent.Delete(se.Event);
                    }
                }

                _repoSport.Delete(_sport);
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

        }

        public bool Update(SportDTO dto)
        {
            try
            {
                Sport sport = _assembler.WriteEntity(dto);
                _repoSport.Update(sport);

                sport.CheckActive();
                //Business question: should we disable all events, selections and market under a sport that is disabled?
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
        }

    }


}
