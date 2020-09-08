using SportsBook.Domain.Model;
using SportsBook.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBook.Services
{
    public class DTOAssembler
    {
        //public SportDTO WriteDTO(Sport sport)
        //{
        //    return new SportDTO()
        //    {

        //    }
        //}

        //public EventDTO WriteDTO(Event event)
        //{

        //}

        //public MarketDTO WriteDTO(Market market)
        //{

        //}

        //public SelectionDTO WriteDTO(Selection selec)
        //{

        //}

        public Sport WriteEntity(SportDTO dto)
        {
            Sport _newSport = new Sport()
            {
                Id = dto.Id,
                Name = dto.Name,
                DisplayName = (String.IsNullOrEmpty(dto.DisplayName) ? dto.Name : dto.DisplayName),
                Active = dto.Active,
                Order = dto.Order,
                Slug = dto.Slug
            };

            return _newSport;
        }

        public Event WriteEntity(EventDTO dto)
        {
            return new Event()
            {
                Id = dto.Id,
                Name = dto.Name,
                Active = dto.Active,
                EventType = dto.EventType,
                Slug = dto.Slug,
                Status = dto.Status
            };
        }

        public Market WriteEntity(MarketDTO dto)
        {
            return new Market()
            {
                Id = dto.Id,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Columns = dto.Columns,
                Order = dto.Order,
                Schema = dto.Schema,
                EventForeignKey = dto.EventForeignKey
            };
        }

        public Selection WriteEntity(SelectionDTO dto)
        {
            return new Selection()
            {
                Id = dto.Id,
                Active = dto.Active,
                Name = dto.Name,
                Outcome = dto.Outcome,
                Price = dto.Price,
                EventId = dto.EventId,
                MarketId = dto.MarketId
            };
        }
    }
}
