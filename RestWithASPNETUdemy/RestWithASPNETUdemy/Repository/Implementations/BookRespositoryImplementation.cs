using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRespositoryImplementation : IBookRepository
    {
        private PostgresContext _context;

        public BookRespositoryImplementation(PostgresContext context) {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public void DeleteById(long bookId)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(bookId));
            if(result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long bookId)
        {
           return _context.Books.SingleOrDefault(p => p.Id.Equals(bookId));
        }

        public Book Update(Book book)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            return book;
        }

        public bool Exist(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id)); ;
        }
    }
}
