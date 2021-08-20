using Mailing.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailing.Repository.Interfaces
{
    public interface IMailingRepository : IReadMailingRepository
    {
        public void InsertNewAccount(UserAccount newAccount);
    }
}
