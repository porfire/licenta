using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class AgentiService : IAgentiService
    {
        public readonly UnitOfWork _UnitOfWork;

        public AgentiService()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public AgentiEntity GetAgentiById(int agentiId)
        {
            var agenti = _UnitOfWork.AgentiRepository.GetByID(agentiId);
            if (agenti != null)
            {
                Mapper.CreateMap<Agenti, AgentiEntity>();
                var agentiModel = Mapper.Map<Agenti, AgentiEntity>(agenti);
                return agentiModel;
            }
            return null;
        }

        public IEnumerable<AgentiEntity> GetAllAgents()
        {
            var agenti = _UnitOfWork.AgentiRepository.GetAll().ToList();
            if (agenti.Any())
            {
                Mapper.CreateMap<Agenti, AgentiEntity>();
                var agentiModel = Mapper.Map<List<Agenti>, List<AgentiEntity>>(agenti);
                return agentiModel;
            }
            return null;
        }

        public int CreateAgent(AgentiEntity agentiEntity)
        {
            var agenti = new Agenti();
            {
                agenti.descriere_agent = agentiEntity.descriere_agent;
                agenti.email_agent = agentiEntity.email_agent;
                agenti.link_facebook = agentiEntity.link_facebook;
                agenti.nume_agent = agentiEntity.nume_agent;
                agenti.telefon_agent = agentiEntity.telefon_agent;
                agenti.telefon_edil = agentiEntity.telefon_edil;

            }
            _UnitOfWork.AgentiRepository.Insert(agenti);
            _UnitOfWork.Save();
             return agenti.agentID;
        }

        public bool UpdateAgent(int agentiId, AgentiEntity agentiEntity)
        {
            var success = false;
            if (agentiEntity != null)
            {
                var agenti = _UnitOfWork.AgentiRepository.GetByID(agentiId);

                if (agenti != null)
                {
                    agenti.descriere_agent = agentiEntity.descriere_agent;
                    agenti.email_agent = agentiEntity.email_agent;
                    agenti.link_facebook = agentiEntity.link_facebook;
                    agenti.nume_agent = agentiEntity.nume_agent;
                    agenti.telefon_agent = agentiEntity.telefon_agent;
                    agenti.telefon_edil = agentiEntity.telefon_edil;
                    _UnitOfWork.AgentiRepository.Update(agenti);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteAgent(int agentiId)
        {

            var success = false;
            if (agentiId > 0)
            {
                var agenti = _UnitOfWork.AgentiRepository.GetByID(agentiId);
                if (agenti != null)
                {
                    _UnitOfWork.AgentiRepository.Delete(agenti);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
