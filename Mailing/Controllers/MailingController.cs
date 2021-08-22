using Mailing.Models.Models;
using Mailing.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Mailing.Controllers
{
    public class MailingController : ApiController
    {
        public IMailingRepository Mailingrepository { get; }
        public MailingController(IMailingRepository Mailingrepository)
        {
            this.Mailingrepository = Mailingrepository;
        }
        [HttpPost]
        public HttpStatusCode PostNewAccount(string lastName, string firstName, string emailAddress)
        {
            try
            {
                var NewUser = new UserAccount(lastName, firstName, emailAddress);
                Mailingrepository.InsertNewAccount(NewUser);
                return HttpStatusCode.Created;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        [HttpGet]
        public List<UserAccount> GetMailingListWithParameters(string LastNameParameters = "", bool SortingOrderParameters = true)
        {
            var userParameters = new UserAccountParameters()
            {
                LastNameParameters = LastNameParameters,
                SortingOrderParameters = SortingOrderParameters
            };
            IEnumerable<UserAccount> Accounts = Mailingrepository.GetAccountsWithParameters(userParameters);

            List<UserAccount> ReturnMailingResult = Accounts.ToList();
            return ReturnMailingResult;
        }
    }
}
