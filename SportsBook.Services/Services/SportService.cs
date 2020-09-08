using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.DTO;
using System;

namespace SportsBook.Services.Services
{
    public class SportService: IServices
    {
        private readonly IGenericRepository<Sport> _repo;
        private readonly IGenericRepository<Event> _eventRepo;
        private readonly DTOAssembler _assembler;

        public SportService(IGenericRepository<Sport> repo, IGenericRepository<Event> eventrepo, DTOAssembler assembler)
        {
            _repo = repo;
            _eventRepo = eventrepo;
            _assembler = assembler;
        }

        public bool Create(SportDTO newSport)
        {
            try
            {
                newSport.Active = false; //Should always start false until a new active event is created
                _repo.Insert(_assembler.WriteEntity(newSport));

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

        public bool Delete(int sportId)
        {
            try
            {
                Sport _sport = _repo.GetByID(sportId);

                //Delete all events linked to the sport first
                if (_sport != null && _sport.SportEventList != null)
                {
                    //TODO: improve this with a delete range option
                    foreach (var se in _sport.SportEventList)
                    {
                        _eventRepo.Delete(se.EventId);
                    }
                }

                _repo.Delete(_sport);

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

        public bool Update(SportDTO dto)
        {
            try
            {
                Sport sport = _assembler.WriteEntity(dto);
                _repo.Update(sport);

                sport.CheckActive();
                //Business question: should we disable all events, selections and market under a sport that is disabled?

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

        //public IEnumerable<SportDTO> Search()
        //{

        //}
    }


}
