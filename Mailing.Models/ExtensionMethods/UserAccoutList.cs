using Mailing.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailing.Models.ExtensionMethods
{
    public static class UserAccoutList
    {
        public static IEnumerable<UserAccount> SortByLastName(this IEnumerable<UserAccount> CurrentList, UserAccountParameters UserParameters)
        {
            if (!string.IsNullOrEmpty(UserParameters.LastNameParameters))
                CurrentList = CurrentList.Where(Account => Account.LastName.Contains(UserParameters.LastNameParameters, StringComparison.InvariantCultureIgnoreCase));
            return CurrentList;
        }

        public static IEnumerable<UserAccount> SortAssending(this IEnumerable<UserAccount> CurrentList, UserAccountParameters UserParameters)
        {
            if (UserParameters.SortingOrderParameters)
                return CurrentList.OrderBy(Account => Account.LastName).ThenBy(Account => Account.Firstname).ToList();
            else
                return CurrentList.OrderByDescending(Account => Account.LastName).ThenByDescending(Account => Account.Firstname).ToList();
        }
    }
}
