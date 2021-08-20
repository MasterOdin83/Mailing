using Mailing.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Mailing.Repository.Interfaces;
using Mailing.Models.ExtensionMethods;

namespace Mailing.Repository
{
    public class MemoryRepository : IMailingRepository
    {
        private static List<UserAccount> Accounts { get; set; }

        public MemoryRepository()
        {
            Accounts = new List<UserAccount>();
        }

        public IEnumerable<UserAccount> ReadAccountsByLastName(string SearchParameter)
        {
            if (string.IsNullOrEmpty(SearchParameter))
                return Accounts;
            var CurrentUsers = Accounts.Where(Account => Account.LastName.Contains(SearchParameter));
            return CurrentUsers;
        }

        public IEnumerable<UserAccount> GetAccounts()
        {
            return Accounts;
        }

        public IEnumerable<UserAccount> GetAccountsWithParameters(UserAccountParameters UserParameters)
        {
            //Option 1
            //IEnumerable<UserAccount> AllAccounts = GetAccounts();
            //IEnumerable<UserAccount> SearchByLastName = AllAccounts.SortByLastName(UserParameters);
            //IEnumerable<UserAccount> SortUserAccounts = SearchByLastName.SortAssending(UserParameters);
            //return SortUserAccounts;

            //Option 2
            //return GetAccounts().SortAssending(UserParameters).SortByLastName(UserParameters);

            //Option 3
            return GetAccounts().SortByLastName(UserParameters).SortAssending(UserParameters);

        }

        public void InsertNewAccount(UserAccount newAccount)
        {
            try
            {
                Accounts.Add(newAccount);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}
