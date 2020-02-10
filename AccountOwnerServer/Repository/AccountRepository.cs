using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindAll()
                .OrderBy(ow => ow.AccountType)
                .ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(Guid accountId)
        {
            return await FindByCondition(account => account.Id.Equals(accountId))
                    .FirstOrDefaultAsync();
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }
    }
}