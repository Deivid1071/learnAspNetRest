using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long personId);
        List<Person> FindAll();
        Person Update(Person person);
        void DeleteById(long personId);

        bool Exist(long id);
    }
}
