namespace Mailing.Models.Models
{
    public class UserAccount
    {
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public string UserEmail { get; set; }
        public UserAccount()
        {

        }
        public UserAccount(string LastName, string Firstname, string UserEmail)
        {
            this.LastName = LastName;
            this.Firstname = Firstname;
            this.UserEmail = UserEmail;
        }
    }
}
