using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class AgentieService : IAgentieService
    {
        public readonly UnitOfWork _UnitOfWork;

        public AgentieService()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public AgentieEntity GetAgencyById(int agencyId)
        {
            var agentie = _UnitOfWork.AgentieRepository.GetByID(agencyId);
            if (agentie != null)
            {
                Mapper.CreateMap<Agentie, AgentieEntity>();
                var agentieModel = Mapper.Map<Agentie, AgentieEntity>(agentie);
                return agentieModel;
            }
            return null;
        }

        public IEnumerable<AgentieEntity> GetAllAgencies()
        {
            var agentie = _UnitOfWork.AgentieRepository.GetAll().ToList();
            if (agentie.Any())
            {
                Mapper.CreateMap<Agentie, AgentieEntity>();
                var agentieModel = Mapper.Map<List<Agentie>, List<AgentieEntity>>(agentie);
                return agentieModel;
            }
            return null;
        }

        public int CreateAgency(AgentieEntity agencyEntity)
        {
            var agency = new Agentie();
            {
                agency.numeAgentie = agencyEntity.descriere;
                agency.descriere = agencyEntity.descriere;
            }
            _UnitOfWork.AgentieRepository.Insert(agency);
            _UnitOfWork.Save();
            return agency.agentieId;
        }

        public bool UpdateAgency(int agencyId, AgentieEntity agencyEntity)

        {
            var success = false;
            if (agencyEntity != null)
            {
                var agency = _UnitOfWork.AgentieRepository.GetByID(agencyId);

                if (agency != null)
                {
                    agency.numeAgentie = agencyEntity.numeAgentie;
                    agency.descriere = agencyEntity.descriere;

                    _UnitOfWork.AgentieRepository.Update(agency);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteAgency(int agencyId)
        {

            var success = false;
            if (agencyId > 0)
            {
                var agency = _UnitOfWork.AgentieRepository.GetByID(agencyId);
                if (agency != null)
                {
                    _UnitOfWork.AgentieRepository.Delete(agency);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
