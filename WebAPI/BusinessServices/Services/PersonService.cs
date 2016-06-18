using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Windows.Forms;
using Antlr.Runtime;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.GenericRepository;
using DataModel.Repository;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class PersonService : IPersonService
    {
        public readonly UnitOfWork _UnitOfWork;
        private readonly IGenericRepository<PersonEntity> m_person;
        public PersonService()
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

        public PersonEntity GetPersonByName()
        {
            var person = _UnitOfWork.PersonRepository.GetAll();
            if (person != null)
            {
                Mapper.CreateMap<Person, PersonEntity>();
                var personModel = Mapper.Map<Person, PersonEntity>(new Person());
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


        /// <summary>
        /// Retrieve a single Account by Email
        /// </summary>
        public PersonEntity GetByEmail(string email)
        {
            return m_person.Where(m => m.email.ToLower() == email.ToLower())
                             .SingleOrDefault();
        }

      
        public PersonEntity Checkperson(int id, string personName, string email)
        {
           // var per = _UnitOfWork.PersonRepository.GetByID(personId);
            var person = new PersonEntity();
            var persons = m_person.GetByID(person.personID);
            if (persons.userName != personName && persons.email != email)
                return persons;
            else
            {
                return null;
            }
        }

        public PersonEntity Checkperson(PersonEntity personEntity)
        {
            //var per = _UnitOfWork.PersonRepository.GetByID(new PersonEntity()).personID;
            //var per = GetPersonByName();
            var per = GetByEmail(personEntity.email);
            //CreatePerson(personEntity);
          //  var persons = m_person.GetByID(personEntity.personID);
            if (personEntity.userName!= per.userName && per.email != personEntity.email)
                return per;
            else
            {
                return null;
            }
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

        /// <summary>
        /// Retrieve a single Account by Email and Password
        /// </summary>
        public PersonEntity GetByEmailAndPassword(string email, string password)
        {
            var hashedPassword = GetPasswordHash(password);

            return m_person.Where(m => m.email.ToLower() == email.ToLower())
                             .Where(m => m.password == hashedPassword)
                             .SingleOrDefault();
        }


        #region Utility Methods

        private string GetPasswordHash(string password)
        {
            using (var hasher = MD5.Create())
            {
                var builder = new StringBuilder();
                var bytes = hasher.ComputeHash(Encoding.Default.GetBytes(password));

                for (int x = 0; x < bytes.Length; x++)
                {
                    builder.Append(bytes[x].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        #endregion


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

        /// <summary>
        /// Public method to authenticate person by person name and password.
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string personName, string password)
        {
            var person = _UnitOfWork.PersonRepository.Get(u => u.userName == personName && u.password == password);
            if (person != null && person.personID > 0)
            {
                return person.personID;
            }
            return 0;
        }

        public static PersonEntity MapTo(Person person)
        {
            if (person == null)
                return null;
            return new PersonEntity()
            {
                userName = person.userName,
                password = person.password,
                nume = person.nume,
                prenume = person.prenume,
                adresa = person.adresa,
                email = person.email,
                telefon = person.telefon,
                varsta = person.varsta
            };
        }

        public Person MapTo(PersonEntity personDto)
        {
            Person pers = new Person();
           // MapTo(pers, personDto);
            return pers;
        }


        public string IsUserNameAvailable(string UserName, string email)
        {
            if (UserExists(UserName, email))
            {
                return UserName;
            }
            else
            {
                return null;
                //var eroare= ("Sorry, " + UserName + " already exist");
                //return eroare;
            }
              
        }
        public int CreatePerson(PersonEntity personEntity)
        {
            var person = new Person();
            person.userName = personEntity.userName;
            person.password = GetPasswordHash(personEntity.password);
            person.nume = personEntity.nume;
            person.prenume = personEntity.prenume;
            person.adresa = personEntity.adresa;
            person.email = personEntity.email;
            person.telefon = personEntity.telefon;
            person.varsta = personEntity.varsta;

            _UnitOfWork.PersonRepository.Insert(person);
            
            // var exista = IsUserNameAvailable(personEntity.userName, personEntity.email);
            var exista = IsUserNameAvailable(personEntity);
            if (exista != null)
            {
                _UnitOfWork.Save();
                return personEntity.personID;
            }
            else
            {
                return (int)MessageBox.Show("userl exista deja");
            }
            
        }

       

        public string IsUserNameAvailable(PersonEntity personEntity)
        {
            var person = UserExists(personEntity);
            if (!person)
            {
                return personEntity.userName;
            }
            else
            {
                return null;
            }
              
        }

        public bool UserExists(string UserName, string email)
        {
           var personEntity = _UnitOfWork.PersonRepository.Where(d => d.userName == UserName && d.email ==email );
            // personEntity.Where(d => d.userName == UserName);
            //var person = m_person.Where(d => d.userName == UserName);
            
            return (personEntity != null);
//;            var usr = _db.Users.FirstOrDefault(d => d.UserName == UserName);
//            return (usr != null);
        }
        public bool UserExists(PersonEntity personEntity)
        {
            var user = _UnitOfWork.PersonRepository.Get();
            //  var username= _UnitOfWork.PersonRepository.Where(d => d.userName == personEntity.userName && d.email == personEntity.email);
            bool am = user.Any(x => x.userName == personEntity.userName);

            if (am)
            {
                return true;
            }

            return false;
            //;            var usr = _db.Users.FirstOrDefault(d => d.UserName == UserName);
            //            return (usr != null);
        }
    }
}
