using Mailing.Models.Models;
using System.Collections.Generic;

namespace Mailing.Repository
{
    public interface IReadMailingRepository
    {
        IEnumerable<UserAccount> ReadAccountsByLastName(string SearchParameter);
        IEnumerable<UserAccount> GetAccounts();
        IEnumerable<UserAccount> GetAccountsWithParameters(UserAccountParameters Parameters);
    }
}