using Mailing.Models.Models;

namespace Mailing.Repository.Interfaces
{
    public interface IMailingRepository : IReadMailingRepository
    {
        public void InsertNewAccount(UserAccount newAccount);
    }
}
