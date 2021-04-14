using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository) 
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void DeleteById(long bookId)
        {
            _repository.DeleteById(bookId);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long bookId)
        {
            return _repository.FindById(bookId);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
