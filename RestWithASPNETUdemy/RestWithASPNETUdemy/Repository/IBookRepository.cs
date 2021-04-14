using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long bookId);
        List<Book> FindAll();
        Book Update(Book book);
        void DeleteById(long bookId);

        bool Exist(long id);
    }
}
