using Entity;
using ViewModels;

namespace Business
{
    public interface IBookBusinessService
    {
        void AddBook(AddBookVM model);
        void UpdateBook(int bookId, AddBookVM model);
        void DeleteBook(int bookId);
        Book GetById(int bookId);
        List<BookListVM> GetAllBooks();
    }
}
