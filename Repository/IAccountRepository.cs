using BusinessObject;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
    {
        List<Account> GetAll();
        List<Account> GetAllByRole(ERole role);
        Account? GetByEmail(string email);
        Account? GetByID(int id);
        Account SaveAccount(Account account);
        bool Login(string username, string password);
        bool Delete(Account account);
    }
}
