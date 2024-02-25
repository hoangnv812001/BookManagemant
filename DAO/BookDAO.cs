using DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO;

public class BookDAO
{
    private readonly RMSContext _dbContext = new();
    private static BookDAO _instance;
    public static BookDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BookDAO();
            }
            return _instance;
        }
    }


    public BookDAO() { }

    public DbSet<Book> GetBooks() => _dbContext.Books;

    public Book SaveBook(Book book)
    {
        if (book.Id != 0)
        {
            _dbContext.Update(book);
        }
        else
        {
            _dbContext.Add(book);
        }
        _dbContext.SaveChanges();
        return book;
    }

    public bool Delete(Book book)
    {

        if (book == null) 
        {
            return false;
        }
        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();  
        return true;
    }

    public bool Update(Book book)
    {

        if (book == null)
        {
            return false;
        }
        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
        return true;
    }
    public Book? GetById(int id) => _dbContext.Books.FirstOrDefault(x => x.Id == id);

    public List<Book> SearchByName(string name) => _dbContext.Books.Where(n =>  n.Name == name).ToList();
}
