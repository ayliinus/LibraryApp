using Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business
{
    public class BookBusinessService : IBookBusinessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookRepositoryService _bookRepository;

        public BookBusinessService(ApplicationDbContext context, IBookRepositoryService bookRepository = null)
        {
            _context = context;
            _bookRepository = bookRepository;
        }


        public void AddBook(AddBookVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newBook = new Book
                    {
                        BookName = model.Name,
                        Author = model.Author,
                        Image = model.Image,
                        Active = true
                    };

                    _bookRepository.Add(newBook);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdateBook(int bookId, AddBookVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingBook = _bookRepository.GetFirst(w => w.Id == bookId);
                    if (existingBook == null)
                    {
                        // Handle error: Book not found
                    }

                    existingBook.BookName = model.Name;
                    existingBook.Author = model.Author;
                    existingBook.Image = model.Image;

                    _bookRepository.Update(existingBook);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingBook = _bookRepository.GetFirst(w => w.Id == bookId);
                    if (existingBook == null)
                    {
                        // Handle error: Book not found
                    }

                    _bookRepository.Delete(existingBook);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Book GetById(int bookId)
        {
            return _bookRepository.GetFirst(w => w.Id == bookId);
        }

        public List<BookListVM> GetAllBooks()
        {
            return _bookRepository.Get(w => w.CreatedAt != null)
                                   .Include(book => book.Members)
                                   .OrderBy(book => book.BookName)
                                   .Select(book => new BookListVM
                                   {
                                       Id = book.Id,
                                       BookName = book.BookName,
                                       Author = book.Author,
                                       BookImage = book.Image,
                                       OnLoan = book.Active ? "Yes" : "No",
                                       CustomerName = book.Members.Any() ? $"{book.Members.First().Name} {book.Members.First().SurName}" : "",
                                       DeliveryDate = book.Members.Any() ? book.Members.First().DeliveryDate.ToString("yyyy-MM-dd HH:mm") : ""
                                   })
                                   .ToList();
        }
    }


}

