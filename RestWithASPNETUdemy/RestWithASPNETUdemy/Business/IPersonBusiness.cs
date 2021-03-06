using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long personId);
        List<Person> FindAll();
        Person Update(Person person);
        void DeleteById(long personId);
    }
}
