using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryEFRepoWebApi.Contracts;
using TryEFRepoWebApi.Infrastructure;
using TryEFRepoWebApi.Models;

namespace TryEFRepoWebApi.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
