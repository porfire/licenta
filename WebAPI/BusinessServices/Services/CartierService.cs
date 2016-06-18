using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class CartierService : ICartierService
    {
        public readonly UnitOfWork _UnitOfWork;

        public CartierService()
        {
            _UnitOfWork = new UnitOfWork();
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

        public int CreatePerson(PersonEntity personEntity)
        {
            var person = new Person();
            {
                person.userName = personEntity.userName;
                person.password = personEntity.password;
                person.nume = personEntity.nume;
                person.prenume = personEntity.prenume;
                person.adresa = personEntity.adresa;
                person.email = personEntity.email;
                person.telefon = personEntity.telefon;
                person.varsta = personEntity.varsta;
                person.userName = personEntity.userName;
                person.password = personEntity.password;

            }
            _UnitOfWork.PersonRepository.Insert(person);
            _UnitOfWork.Save();
             return person.personID;
        }

        public bool UpdatePerson(int personId, PersonEntity personEntity)
        {
            var success = false;
            if (personEntity != null)
            {
                    var person = _UnitOfWork.PersonRepository.GetByID(personId);

                    if (person != null)
                    {
                        person.nume = personEntity.nume;
                        _UnitOfWork.PersonRepository.Update(person);
                        _UnitOfWork.Save();
                        success = true;
                    }
                }
            return success;
        }

        public bool DeletePerson(int personId)
        {

            var success = false;
            if (personId > 0)
            {
                var person = _UnitOfWork.PersonRepository.GetByID(personId);
                if (person != null)
                {
                    _UnitOfWork.PersonRepository.Delete(person);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public CartierEntity GetCartierById(int cartierId)
        {
            var cartier = _UnitOfWork.CartierRepository.GetByID(cartierId);
            if (cartier != null)
            {
                Mapper.CreateMap<Cartier, CartierEntity>();
                var cartierModel = Mapper.Map<Cartier, CartierEntity>(cartier);
                return cartierModel;
            }
            return null;
        }
        
        public IEnumerable<CartierEntity> GetAllCartiers()
        {
            var cartier = _UnitOfWork.CartierRepository.GetAll().ToList();
            if (cartier.Any())
            {
                Mapper.CreateMap<Cartier, CartierEntity>();
                var cartierModel = Mapper.Map<List<Cartier>, List<CartierEntity>>(cartier);
                return cartierModel;
            }
            return null;
        }

        public int CreateCartier(CartierEntity cartierEntity)
        {
            var cartier=new Cartier();
            cartier.denumire_cartier = cartierEntity.denumire_cartier;
            cartier.latitudine_longitudine = cartierEntity.latitudine_longitudine;
            _UnitOfWork.CartierRepository.Insert(cartier);
            _UnitOfWork.Save();
            return cartier.id_cartier;
        }

        public bool UpdateCartier(int cartierId, CartierEntity cartierEntity)
        {
            var success = false;
            if (cartierEntity != null)
            {
                var cartier = _UnitOfWork.CartierRepository.GetByID(cartierId);

                if (cartier != null)
                {
                    cartier.denumire_cartier = cartierEntity.denumire_cartier;
                    cartier.latitudine_longitudine = cartierEntity.latitudine_longitudine;
                    _UnitOfWork.CartierRepository.Update(cartier);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteCartier(int cartierId)
        {
            var succes = false;
            if (cartierId > 0)
            {
                var cartier = _UnitOfWork.CartierRepository.GetByID(cartierId);
                if (cartier != null)
                {
                    _UnitOfWork.CartierRepository.Delete(cartier);
                    _UnitOfWork.Save();
                    return succes = true;
                }
            }
            return succes;
        }
    }
}
