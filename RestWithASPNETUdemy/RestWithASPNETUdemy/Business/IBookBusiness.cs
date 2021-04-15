using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long bookId);
        List<Book> FindAll();
        Book Update(Book book);
        void DeleteById(long bookId);
    }
}
