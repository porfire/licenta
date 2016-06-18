using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class LocalitateService : ILocalitateService
    {
        public readonly UnitOfWork _UnitOfWork;

        public LocalitateService()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public PersonEntity GetPersonById(int personId)
        {
            var person = _UnitOfWork.PersonRepository.GetByID(personId);
            if (person != null)
            {
                Mapper.CreateMap<Person, PersonEntity>();
                var personModel = Mapper.Map<Person, PersonEntity>(person);
                return personModel;
            }
            return null;
        }

        public IEnumerable<PersonEntity> GetAllPersons()
        {
            var persons = _UnitOfWork.PersonRepository.GetAll().ToList();
            if (persons.Any())
            {
                Mapper.CreateMap<Person, PersonEntity>();
                var personModel = Mapper.Map<List<Person>, List<PersonEntity>>(persons);
                return personModel;
            }
            return null;
        }

        public LocalitateEntity GetLocalitateById(int localitateId)
        {

            var localitate = _UnitOfWork.LocalitateRepository.GetByID(localitateId);
            if (localitate!= null)
            {
                Mapper.CreateMap<Localitate, LocalitateEntity>();
                var localitateModel = Mapper.Map<Localitate,LocalitateEntity>(localitate);
                return localitateModel;
            }
            return null;
        }

        public IEnumerable<LocalitateEntity> GetAllLocalitates()
        {
            var localitate = _UnitOfWork.LocalitateRepository.GetAll().ToList();
            if (localitate.Any())
            {
                Mapper.CreateMap<Localitate, LocalitateEntity>();
                var localitateModel = Mapper.Map<List<Localitate>, List<LocalitateEntity>>(localitate);
                return localitateModel;
            }
            return null;
        }

        public int CreateLocalitate(LocalitateEntity localitateEntity)
        {
            var localitate= new Localitate();
            localitate.denumire_localitate = localitateEntity.denumire_localitate;
            localitate.latitudine = localitateEntity.latitudine;
            localitate.longitudine = localitateEntity.longitudine;

            _UnitOfWork.LocalitateRepository.Insert(localitate);
            _UnitOfWork.Save();
            return localitate.localitateID;
        }

        public bool UpdateLocalitate(int localitateId, LocalitateEntity localitateEntity)
        {
            var success = false;
            if (localitateEntity != null)
            {
                var localitate = _UnitOfWork.LocalitateRepository.GetByID(localitateId);

                if (localitate != null)
                {
                    localitate.denumire_localitate = localitateEntity.denumire_localitate;
                    localitate.latitudine = localitateEntity.latitudine;
                    localitate.longitudine = localitateEntity.longitudine;
                    _UnitOfWork.LocalitateRepository.Update(localitate);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteLocalitate(int localitateId)
        {
            var success = false;
            if (localitateId > 0)
            {
                var localitate = _UnitOfWork.LocalitateRepository.GetByID(localitateId);
                if (localitate != null)
                {
                    _UnitOfWork.LocalitateRepository.Delete(localitate);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
