using Mailing.Models.Models;
using Mailing.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Mailing.Repository
{
    public class CSVRepository : IMailingRepository
    {
        public CSVRepository()
        {

        }
        public IEnumerable<UserAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> GetAccountsWithParameters(UserAccountParameters Parameters)
        {
            throw new NotImplementedException();
        }

        public void InsertNewAccount(UserAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> ReadAccountsByLastName(string SearchParameter)
        {
            throw new NotImplementedException();
        }
    }
}
