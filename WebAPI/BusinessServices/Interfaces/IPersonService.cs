using System.Collections.Generic;
using BusinessEntities.Entities;
using DataModel;

namespace BusinessServices.Interfaces
{
    public interface IPersonService
    {
        PersonEntity GetPersonById(int personId);
        IEnumerable<PersonEntity> GetAllPersons();
        int CreatePerson(PersonEntity personEntity);
        bool UpdatePerson(int personId, PersonEntity personEntity);
        bool DeletePerson(int personId);
        int Authenticate(string username, string password);
        PersonEntity Checkperson(int id,string personName, string password);
        PersonEntity GetByEmailAndPassword(string email, string password);
        //PersonEntity GetPersonByName(string userName, string email);
        PersonEntity GetPersonByName();
        bool UserExists(string UserName, string email);
        PersonEntity GetByEmail(string email);

    }
}