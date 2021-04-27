
using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null)
            {
                return null;

            }
            else
            {
                return new BookVO
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LauchDate = origin.LauchDate,
                    Price = origin.Price,
                    Title = origin.Title,
                };
            }
        }

        

        public Book Parse(BookVO origin)
        {
            if (origin == null)
            {
                return null;

            }
            else
            {
                return new Book
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LauchDate = origin.LauchDate,
                    Price = origin.Price,
                    Title = origin.Title,
                };
            }
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            throw new NotImplementedException();
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            throw new NotImplementedException();
        }
    }
}
