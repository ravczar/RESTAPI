using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(Guid accountId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
