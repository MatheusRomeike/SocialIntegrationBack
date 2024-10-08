﻿using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;
using Application.Context;
using Domain.Entities.Account;


namespace Data.Repository
{
    public class AccountRepository : BaseRepository<Account, DataContext>, IAccountRepository
    {
        private readonly DataContext Context;

        public AccountRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
