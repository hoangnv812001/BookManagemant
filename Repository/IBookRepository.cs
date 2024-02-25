using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        List<Book> SearchByName(string name);
        Book? GetById(int id);
        bool Delete(Book book);
        Book SaveBook(Book book);
        Book? GetByName(string bookName);

    }
}
