using BusinessObject;
using DAO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository() { }

        public bool Delete(Account account)
        {
            if(account != null && account.Id > 0)
            {
                AccountDAO.Instance.Delete(account); 
                return true;
            }
            return false;
        }
        public bool Update(Account account)
        {
            if(account != null && account.Id > 0)
            {
                AccountDAO.Instance.Update(account);
                return true;
            }
            return false;
        }

        public List<Account> GetAll() => AccountDAO.Instance.GetAccounts().ToList();
        public List<Account> GetAllByRole(ERole role) => AccountDAO.Instance.GetAccounts().Where(a => a.Role == (int)role).ToList();
        public Account? GetByEmail(string email) => AccountDAO.Instance.GetAccounts().Where(a => a.Email == email).FirstOrDefault(); 
        public Account? GetByID(int id) => AccountDAO.Instance.GetAccounts().Where(a => a.Id == id).FirstOrDefault();
        public bool Login(string email, string password)
        {
            int result = 0;
            return AccountDAO.Instance.GetAccounts().Where(a => (a.Email == email || (int.TryParse(email, out result) && a.Id == result)) && a.Password == password).Any(); 
        }

       
        public Account SaveAccount(Account account)
        {
            return AccountDAO.Instance.SaveAccount(account);
        }
    }
}
