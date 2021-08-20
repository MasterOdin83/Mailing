using Mailing.Models.Models;
using Mailing.Repository;
using Mailing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

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
            var NewUser = new UserAccount(lastName, firstName, emailAddress);
            Mailingrepository.InsertNewAccount(NewUser);
            return HttpStatusCode.Created;
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
