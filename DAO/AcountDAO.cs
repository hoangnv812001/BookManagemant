
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private readonly RMSContext _dbContext = new();

        private static AccountDAO _instance;

        public static AccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAO();
                }
                return _instance;
            }
        }
        public AccountDAO() { }

        public DbSet<Account> GetAccounts() => _dbContext.Accounts;

        public Account SaveAccount(Account account)
        {
            if (account.Id == 0)
            {
                _dbContext.Accounts.Add(account);
            }else
            {
                _dbContext.Accounts.Update(account);
            }
            _dbContext.SaveChanges();
            return _dbContext.Accounts.Where(a => a.Email == account.Email).First();

        }
        public void Delete(Account account)
        {
            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }
        public void Update(Account account)
        {
            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }

    }
}
