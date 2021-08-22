using Mailing.Repository.Interfaces;
using NUnit.Framework;
using Mailing.Models.Models;
using Mailing.Repository;
using System.Linq;
using Mailing.Models;

namespace Mailing.Test
{
    public class RepositoryUnitTest
    {
        private IMailingRepository Mailingrepository;
        public RepositoryUnitTest()
        {
            Mailingrepository = new MemoryRepository();

            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Zapata", Firstname = "Eduardo", UserEmail = "zapata.eduardo@mailinator.com" });
            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Zapata", Firstname = "Miguel", UserEmail = "zapata.miguel@mailinator.com" });

            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Gome", Firstname = "Miguel", UserEmail = "zapata.miguel@mailinator.com" });
            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Gomez", Firstname = "Hector", UserEmail = "Gomez.Hector@mailinator.com" });
            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Gomez", Firstname = "Adrian", UserEmail = "Gomez.Hector@mailinator.com" });
            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Gomez", Firstname = "Eduardo", UserEmail = "zapata.miguel@mailinator.com" });

            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Albarran", Firstname = "Eduardo", UserEmail = "Albarran.Eduardo@mailinator.com" });
            Mailingrepository.InsertNewAccount(new UserAccount() { LastName = "Albarran", Firstname = "Miguel", UserEmail = "Albarran.Miguel@mailinator.com" });
        }

        [Test]
        public void WhenSortingAsscendingFirstReultLastNameStartsWith_A()
        {
            ///Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { SortingOrderParameters = true });

            ///Act
            var FirsUserFromList = UserList.FirstOrDefault();

            ///Assert
            Assert.AreEqual(FirsUserFromList.LastName, "Albarran");

        }
        [Test]
        public void WhenSortingAsscendingFirstReultLastNameStartsWith_AAndFirstNameIsNowSorted()
        {
            ///Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { SortingOrderParameters = true });

            ///Act
            var FirsUserFromList = UserList.FirstOrDefault();

            ///Assert
            Assert.AreEqual(FirsUserFromList.LastName, "Albarran");
            Assert.AreEqual(FirsUserFromList.Firstname, "Eduardo");

        }
        [Test]
        public void WhenSortingDesendingFirstReultLastNameStartsWith_Z()
        {
            ///Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { SortingOrderParameters = false });

            ///Act
            var FirsUserFromList = UserList.FirstOrDefault();

            ///Assert
            Assert.AreEqual(FirsUserFromList.LastName, "Zapata");
        }
        [Test]
        public void WhenSortingDesendingFirstReultLastNameStartsWith_ZAndFirstNameIsNowSorted()
        {
            ///Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { SortingOrderParameters = false });

            ///Act
            var FirsUserFromList = UserList.FirstOrDefault();

            ///Assert
            Assert.AreEqual(FirsUserFromList.LastName, "Zapata");
            Assert.AreEqual(FirsUserFromList.Firstname, "Miguel");
        }
        [Test]
        public void WhenSearchingALastNameGome4ResultAreExpected()
        {
            //Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { LastNameParameters = "Gomez" });

            //Act
            var ResultsReceivedCount = UserList.Count();

            //Assert
            Assert.AreEqual(3, ResultsReceivedCount);
        }
        [Test]
        public void WhenSearchingALastNameGomez3ResultAreExpected()
        {
            //Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { LastNameParameters = "Gome" });

            //Act
            var ResultsReceivedCount = UserList.Count();

            //Assert
            Assert.AreEqual(4, ResultsReceivedCount);
        }
        [Test]
        public void WhenSearchingALastNameGome4ResultAreExpectedAndSortingAsending()
        {
            //Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { LastNameParameters = "Gomez", SortingOrderParameters = true });

            //Act
            var FirstUserFromList = UserList.FirstOrDefault();
            var ResultsReceivedCount = UserList.Count();

            //Assert
            Assert.AreEqual(3, ResultsReceivedCount);
            Assert.AreEqual(FirstUserFromList.Firstname, "Adrian");
        }
        [Test]
        public void WhenSearchingALastNameGome4ResultAreExpectedAndSortingDescending()
        {
            //Arrange
            var UserList = Mailingrepository.GetAccountsWithParameters(new UserAccountParameters() { LastNameParameters = "Gomez" , SortingOrderParameters= false});

            //Act
            var FirstUserFromList = UserList.FirstOrDefault();
            var ResultsReceivedCount = UserList.Count();

            //Assert
            Assert.AreEqual(3, ResultsReceivedCount);
            Assert.AreEqual(FirstUserFromList.Firstname, "Hector");
        }
    }
}