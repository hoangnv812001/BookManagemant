using DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AuthorDAO
    {
        private readonly RMSContext _dbcontext = new();
        private static AuthorDAO _instance;
        public static AuthorDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthorDAO();
                }
                return _instance;
            }
        }
        public AuthorDAO() { }

        public DbSet<Author> Get() => _dbcontext.Authors;
    }
}
