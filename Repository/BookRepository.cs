using DAO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repository
{
    public  class BookRepository :IBookRepository
    {
        public bool Delete(Book book) => BookDAO.Instance.Delete(book);
        public List<Book> GetAll() => BookDAO.Instance.GetBooks().ToList();
        public Book? GetById(int id) => BookDAO.Instance.GetById(id);
        public Book Save(Book book) => BookDAO.Instance.SaveBook(book);
        public List<Book> SearchByName(string keyname) => BookDAO.Instance.SearchByName(keyname);
        public bool Update(Book book) => BookDAO.Instance.Update(book);
        public Book? GetByName(string name) => BookDAO.Instance.GetBooks().Where(a => a.Name == name).FirstOrDefault();

        public BookRepository() { }

        public Book SaveBook(Book book)
        {
            return BookDAO.Instance.SaveBook(book);
        }
    }
}
